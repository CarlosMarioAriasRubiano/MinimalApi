namespace MinimalApi.Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SubModel { get; set; } = string.Empty;
        public Guid LocationId { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Location Location { get; set; } = default!;
        public virtual Customer Customer { get; set; } = default!;
        public virtual IEnumerable<BuyerVehicle> BuyerVehicles { get; set; } = default!;
    }
}
