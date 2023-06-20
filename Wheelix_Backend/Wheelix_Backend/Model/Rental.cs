using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wheelix_Backend.Model
{
    public class Rental
    {
        //public int Id { get; set; }
        //public int carId { get; set; }
        //public int driverId { get; set; }
        //public string additionalsId { get; set; }
        //public DateTime rentalDate { get; set; }
        //public DateTime startDate { get; set; }
        //public DateTime endDate { get; set; }
        //[Column(TypeName = "decimal(10,2)")] Specify the store type as decimal with precision 10 and scale 2
        //public decimal totalCost { get; set; }
        //public string payment { get; set; }

        public int Id { get; set; }
        public string trackingCode { get; set; }
        public string locationName { get; set; }
        public string locationAddress { get; set; }
        public string carName { get; set; }
        public string carType { get; set; }
        public string driverName { get; set; }
        public string driverPhone { get; set; }
        public string driverEmail { get; set; }
        public string additionals { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal totalCost { get; set; }
        public string payment { get; set; }
    }
}
