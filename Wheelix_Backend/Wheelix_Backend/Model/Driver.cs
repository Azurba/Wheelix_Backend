namespace Wheelix_Backend.Model
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string DriverLicense { get; set; }
        //public int? RentalId { get; set; } // Foreign key to Rental

        //public Rental? Rental { get; set; } // Navigation property

        //public Driver()
        //{
        //    RentalId = null;
        //    Rental = null;
        //}
    }
}
