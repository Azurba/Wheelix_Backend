using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wheelix_Backend.Model;

namespace Wheelix_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly WheelixDBContext context;

        public CarController(WheelixDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            var cars = await context.Car.ToListAsync();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            context.Car.Add(car);
            await context.SaveChangesAsync();

            return Ok(car);
        }

        [HttpPost("multiple")]
        public IActionResult AddMultipleCars([FromBody] List<Car> cars) {
            try {
                if (cars == null || cars.Count == 0) {
                    return BadRequest("No Cars provided");
                }

                foreach (var car in cars) {
                    context.Car.Add(car);
                }

                context.SaveChanges();

                return Ok("Cars added successfully");
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
        }
    }

}

