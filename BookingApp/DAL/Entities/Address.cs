namespace BookingApp.DAL.Entities
{
    internal class Address
    {
        public required string Country { get; set; }
        public required string City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? PostalCode { get; set; }
    }
}
