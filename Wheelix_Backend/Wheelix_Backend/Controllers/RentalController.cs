using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Wheelix_Backend.Model;

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
        [HttpPost]
        public async Task<ActionResult<Rental>> addRental(Rental rental) {
            context.Rental.Add(rental);
            await context.SaveChangesAsync();
            return Ok(rental);
        }
    }
}
