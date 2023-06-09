using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Wheelix_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Wheelix_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly WheelixDBContext context; //EF
        private readonly IDbConnection dbConnection; //Dapper

        public RentalController(WheelixDBContext context, IDbConnection dbConnection)
        {
            this.context = context; //EF
            this.dbConnection = dbConnection; //Dapper)
        }

        //Dapper
        [HttpGet]
        public async Task<ActionResult<List<Rental>>> getAllRentals() {
            var rentals = await dbConnection.QueryAsync<Rental>("SELECT * FROM Rental");
            return Ok(rentals.ToList());
        }

        //Dapper
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> SearchRental(int id) {
            var rental = await dbConnection.QuerySingleOrDefaultAsync<Rental>("SELECT * FROM Rental WHERE Id = @Id", new { @Id = id });
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        
        //EF and LINQ
        [HttpPost]
        public async Task<ActionResult<Rental>> AddRental(Rental rental)
        {
            // Check if the car with the specified ID exists before allow the rental to be added
            bool isCarExists = await context.Car.AnyAsync(c => c.Id == rental.carId);
            if (!isCarExists)
            {
                ModelState.AddModelError("carId", "Car with the specified ID does not exist.");
                return BadRequest(ModelState);
            }

            // Check if the driver with the specified ID exists before allow the rental to be added
            bool isDriverExists = await context.Driver.AnyAsync(d => d.Id == rental.driverId);
            if (!isDriverExists)
            {
                ModelState.AddModelError("driverId", "Driver with the specified ID does not exist.");
                return BadRequest(ModelState);
            }

            // Check if the car is already used in another rental
            bool isCarInUse = await context.Rental.AnyAsync(r => r.carId == rental.carId);
            if (isCarInUse)
            {
                ModelState.AddModelError("carId", "This car is unavailable. Already in use.");
                return BadRequest(ModelState);
            }

            // Since additionalsId is a string of Ids, separated by comma we need to split the additionalsId string into individual IDs
            var additionalsIds = rental.additionalsId.Split(',');

            // Check if all additionals with the specified IDs exist before allow the rental to be added
            List<int> nonExistingAdditionalsIds = context.Additionals
                .Where(a => additionalsIds.Contains(a.Id.ToString()))
                .Select(a => a.Id)
                .ToList()
                .Except(additionalsIds.Select(int.Parse))
                .ToList();

            if (nonExistingAdditionalsIds.Any())
            {
                ModelState.AddModelError("additionalsId", $"Additionals with the following IDs do not exist: {string.Join(", ", nonExistingAdditionalsIds)}");
                return BadRequest(ModelState);
            }

            //Add the rental only after all the checks have passed
            context.Rental.Add(rental);
            await context.SaveChangesAsync();
            return Ok(rental);
        }

        //Dapper
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id){
            var query = "DELETE FROM Rental WHERE Id = @Id";
            var affectedRow = await dbConnection.ExecuteAsync(query, new { Id = id });

            if (affectedRow == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //EF
        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            context.Rental.RemoveRange(context.Rental);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
