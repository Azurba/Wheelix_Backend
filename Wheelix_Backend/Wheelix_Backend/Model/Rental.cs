﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wheelix_Backend.Model
{
    public class Rental
    {
        public int Id { get; set; }
        public int carId { get; set; }
        public int driverId { get; set; }
        public string additionalsId { get; set; }
        public DateTime rentalDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        [Column(TypeName = "decimal(10,2)")] // Specify the store type as decimal with precision 10 and scale 2
        public decimal totalCost { get; set; }
        public string payment { get; set; }
    }
}
