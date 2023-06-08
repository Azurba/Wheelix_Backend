using Microsoft.EntityFrameworkCore;


namespace Wheelix_Backend

{
    public class WheelixDBContext : DbContext
    {
        public WheelixDBContext(DbContextOptions<WheelixDBContext> options) : base(options)
        {

        }
    }
}
