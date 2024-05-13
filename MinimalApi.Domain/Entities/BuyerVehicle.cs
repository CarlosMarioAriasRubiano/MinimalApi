namespace MinimalApi.Domain.Entities
{
    public class BuyerVehicle
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsCurrent { get; set; }
        public Guid BuyerId { get; set; }
        public Guid VehicleId { get; set; }

        public virtual Buyer Buyer { get; set; } = default!;
        public virtual Vehicle Vehicle { get; set; } = default!;
        public virtual IEnumerable<BuyerVehicleHistory> BuyerVehicleHistories { get; set; } = default!;
    }
}
