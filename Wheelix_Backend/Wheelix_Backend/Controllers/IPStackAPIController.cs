using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Wheelix_Backend.Model;

namespace Wheelix_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPStackAPIController : ControllerBase
    {
        private readonly WheelixDBContext context; //EF

        public IPStackAPIController(WheelixDBContext context)
        {
            this.context = context; //EF
        }

        [HttpGet]
        public async Task<ActionResult<List<IPStackAPI>>> GetKey()
        {
            var key = await context.IPStackAPI.ToListAsync();
            return Ok(key);
        }
    }
}
