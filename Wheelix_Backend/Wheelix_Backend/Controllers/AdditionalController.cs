using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Wheelix_Backend.Model;

namespace Wheelix_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalController : ControllerBase
    {
        private readonly WheelixDBContext context; //EF
        private readonly IDbConnection dbConnection; //Dapper

        public AdditionalController(WheelixDBContext context, IDbConnection dbConnection)
        {
            this.context = context; //EF
            this.dbConnection = dbConnection; //Dapper)
        }

        //Dapper
        [HttpGet]
        public async Task<ActionResult<List<Additionals>>> getAllAdditionals()
        {
            var additionals = await dbConnection.QueryAsync<Additionals>("SELECT * FROM Additionals");
            return Ok(additionals.ToList());
        }

        //Dapper
        [HttpGet("{id}")]
        public async Task<ActionResult<Additionals>> SearchAdditional(int id)
        {
            var additionals = await dbConnection.QuerySingleOrDefaultAsync<Additionals>("SELECT * FROM Additionals WHERE Id = @Id", new { @Id = id });
            if (additionals == null)
            {
                return NotFound();
            }

            return Ok(additionals);
        }

        //EF
        [HttpPost]
        public async Task<ActionResult<Additionals>> AddDriver(Additionals additionals)
        {
            context.Additionals.Add(additionals);
            await context.SaveChangesAsync();

            return Ok(additionals);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var query = "DELETE FROM Additionals WHERE Id = @Id";
            var affectedRows = await dbConnection.ExecuteAsync(query, new { Id = id });

            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //EF
        //[HttpDelete]
        //public async Task<ActionResult> DeleteAll()
        //{
        //    context.Additionals.RemoveRange(context.Additionals);
        //    await context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
