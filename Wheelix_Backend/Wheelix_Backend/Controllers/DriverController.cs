﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Wheelix_Backend.Model;

namespace Wheelix_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly WheelixDBContext context; //EF
        private readonly IDbConnection dbConnection; //Dapper

        public DriverController(WheelixDBContext context, IDbConnection dbConnection)
        {
            this.context = context; //EF
            this.dbConnection = dbConnection; //Dapper)
        }

        //Dapper
        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetAllDrivers() {
            var drivers = await dbConnection.QueryAsync<Driver>("SELECT * FROM Driver");
            return Ok(drivers.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> SearchDriver(int id)
        {
            var driver = await dbConnection.QuerySingleOrDefaultAsync<Driver>("SELECT * FROM Driver WHERE Id = @Id", new { Id = id });

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

            //EF
            [HttpPost]
        public async Task<ActionResult<Driver>> AddDriver(Driver driver)
        {
            context.Driver.Add(driver);
            await context.SaveChangesAsync();

            return Ok(driver);
        }

        //[HttpPost]
        //public async Task<ActionResult<Driver>> AddDriver(Driver driver) { 
        //    var query = ""
        //}
    
    }
}
