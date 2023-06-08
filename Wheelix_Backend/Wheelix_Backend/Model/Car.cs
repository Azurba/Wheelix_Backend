using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wheelix_Backend.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int BadSupport { get; set; }
        public int PeopleSupport { get; set; }
        public string LicencePlate { get; set; }
        [Column(TypeName = "decimal(10,2)")] // Specify the store type as decimal with precision 10 and scale 2
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
