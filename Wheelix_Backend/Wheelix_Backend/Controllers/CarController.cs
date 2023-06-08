using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using Wheelix_Backend.Model;

namespace Wheelix_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly WheelixDBContext context; //EF
        private readonly IDbConnection dbConnection; //Dapper

        public CarController(WheelixDBContext context, IDbConnection dbConnection)
        {
            this.context = context; //EF
            this.dbConnection = dbConnection; //Dapper
        }

        //EF
        //[HttpGet]
        //public async Task<ActionResult<List<Car>>> GetAllCars()
        //{
        //    var cars = await context.Car.ToListAsync();
        //    return Ok(cars);
        //}

        //Dapper
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars() {
            var cars = await dbConnection.QueryAsync<Car>("SELECT * FROM Car");
            return Ok(cars.ToList());
        }

        //EF
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Car>> SearchCar(int id)
        //{

        //    var car = await context.Car.FindAsync(id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(car);
        //}

        //Dapper
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> SearchCar(int id) {
            var car = await dbConnection.QuerySingleOrDefaultAsync<Car>("SELECT * FROM Car WHERE Id = @Id", new { Id = id });

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        //EF
        //[HttpGet("type/{carType}")]
        //public async Task<ActionResult<List<Car>>> getCarByType(string carType)
        //{
        //    var cars = await context.Car.Where(p => p.Type == carType).ToListAsync();

        //    if (cars == null || cars.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cars);
        //}

        //Dapper
        [HttpGet("type/{carType}")]
        public async Task<ActionResult<List<Car>>> getCarByType(string carType) {
            var car = await dbConnection.QueryAsync<Car>("SELECT * FROM Car WHERE Type=@Type", new { Type = carType });

            if (!car.Any())
            {
                return NotFound();
            }

            return Ok(car.ToList());
        }

        //EF
        //[HttpPost]
        //public async Task<ActionResult<Car>> AddCar(Car car)
        //{
        //    context.Car.Add(car);
        //    await context.SaveChangesAsync();

        //    return Ok(car);
        //}

        //Dapper
        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car) {
            var query = "INSERT INTO Car (Model, Manufacturer, Type, Color, BagSupport, PeopleSupport, LicencePlate, Price, Image) " +
                "VALUES (@Model, @Manufacturer, @Type, @Color, @BagSupport, @PeopleSupport, @LicencePlate, @Price, @Image);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)";
            /*The statement SELECT CAST(SCOPE_IDENTITY() AS INT) is used to retrieve the last identity value generated in the current scope. 
             * In the context of your code snippet, it is used after an INSERT statement to retrieve the newly inserted record's ID.
             */

            var carId = await dbConnection.QuerySingleAsync<int>(query, car);
            car.Id = carId;

            return Ok(car);
        }

        //EF
        [HttpPost("multiple")]
        public IActionResult AddMultipleCars([FromBody] List<Car> cars)
        {
            try
            {
                if (cars == null || cars.Count == 0)
                {
                    return BadRequest("No Cars provided");
                }

                foreach (var car in cars)
                {
                    context.Car.Add(car);
                }

                context.SaveChanges();

                return Ok("Cars added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //EF
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteById(int id)
        //{

        //    var car = await context.Car.FindAsync(id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }
        //    context.Car.Remove(car);
        //    await context.SaveChangesAsync();

        //    return NoContent();
        //}

        //Dapper
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id) {
            var query = "DELETE FROM Car WHERE Id = @Id";
            var affectedRows = await dbConnection.ExecuteAsync(query, new { Id = id });

            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //EF
        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            context.Car.RemoveRange(context.Car);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }

    //DAPPER

    //[Route("api/[controller]")]
    //[ApiController]
    //public class CarController : ControllerBase
    //{
    //    private readonly IDbConnection _dbConnection;

    //    public CarController(IDbConnection dbConnection)
    //    {
    //        _dbConnection = dbConnection;
    //    }

    //    [HttpGet]
    //    public async Task<ActionResult<List<Car>>> GetAllCars()
    //    {
    //        var cars = await _dbConnection.QueryAsync<Car>("SELECT * FROM Car");
    //        return Ok(cars.ToList());
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Car>> SearchCar(int id)
    //    {
    //        var car = await _dbConnection.QuerySingleOrDefaultAsync<Car>("SELECT * FROM Car WHERE Id = @Id", new { Id = id });

    //        if (car == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(car);
    //    }

    //    [HttpGet("type/{carType}")]
    //    public async Task<ActionResult<List<Car>>> GetCarByType(string carType)
    //    {
    //        var cars = await _dbConnection.QueryAsync<Car>("SELECT * FROM Car WHERE Type = @Type", new { Type = carType });

    //        if (!cars.Any())
    //        {
    //            return NotFound();
    //        }

    //        return Ok(cars.ToList());
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<Car>> AddCar(Car car)
    //    {
    //        var query = "INSERT INTO Car (Model, Manufacturer, Type, Color, BagSupport, PeopleSupport, LicencePlate, Price, Image) " +
    //                    "VALUES (@Model, @Manufacturer, @Type, @Color, @BagSupport, @PeopleSupport, @LicencePlate, @Price, @Image);" +
    //                    "SELECT CAST(SCOPE_IDENTITY() AS INT)";

    //        var carId = await _dbConnection.QuerySingleAsync<int>(query, car);
    //        car.Id = carId;

    //        return Ok(car);
    //    }

    //    [HttpPost("multiple")]
    //    public IActionResult AddMultipleCars([FromBody] List<Car> cars)
    //    {
    //        try
    //        {
    //            if (cars == null || !cars.Any())
    //            {
    //                return BadRequest("No Cars provided");
    //            }

    //            var query = "INSERT INTO Car (Model, Manufacturer, Type, Color, BagSupport, PeopleSupport, LicencePlate, Price, Image) " +
    //                        "VALUES (@Model, @Manufacturer, @Type, @Color, @BagSupport, @PeopleSupport, @LicencePlate, @Price, @Image)";

    //            _dbConnection.Execute(query, cars);

    //            return Ok("Cars added successfully");
    //        }
    //        catch (Exception ex)
    //        {
    //            return StatusCode(500, ex.Message);
    //        }
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult> DeleteById(int id)
    //    {
    //        var query = "DELETE FROM Car WHERE Id = @Id";
    //        var affectedRows = await _dbConnection.ExecuteAsync(query, new { Id = id });

    //        if (affectedRows == 0)
    //        {
    //            return NotFound();
    //        }

    //        return NoContent();
    //    }
    //}
}