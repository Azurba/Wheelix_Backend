namespace Wheelix_Backend.Model
{
    public class Additionals
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
