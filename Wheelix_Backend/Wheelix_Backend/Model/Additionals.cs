using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wheelix_Backend.Model
{
    public class Additionals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        [Column(TypeName = "decimal(10,2)")] // Specify the store type as decimal with precision 10 and scale 2
        public decimal price { get; set; }

    }
}
