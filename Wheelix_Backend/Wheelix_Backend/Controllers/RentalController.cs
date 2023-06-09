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

        //EF
        //[HttpPost]
        //public async Task<ActionResult<Rental>> addRental(Rental rental) {
        //    context.Rental.Add(rental);
        //    await context.SaveChangesAsync();
        //    return Ok(rental);
        //}
        [HttpPost]
        public async Task<ActionResult<Rental>> AddRental(Rental rental)
        {
            // Check if the car with the specified ID exists
            bool isCarExists = await context.Car.AnyAsync(c => c.Id == rental.carId);
            if (!isCarExists)
            {
                ModelState.AddModelError("carId", "Car with the specified ID does not exist.");
                return BadRequest(ModelState);
            }

            // Check if the driver with the specified ID exists
            bool isDriverExists = await context.Driver.AnyAsync(d => d.Id == rental.driverId);
            if (!isDriverExists)
            {
                ModelState.AddModelError("driverId", "Driver with the specified ID does not exist.");
                return BadRequest(ModelState);
            }

            // Split the additionalsId string into individual IDs
            var additionalsIds = rental.additionalsId.Split(',');

            // Check if all additionals with the specified IDs exist
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

            context.Rental.Add(rental);
            await context.SaveChangesAsync();
            return Ok(rental);
        }



    }
}
