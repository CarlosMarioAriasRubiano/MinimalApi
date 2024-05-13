namespace MinimalApi.Domain.Entities
{
    public class BuyerVehicleHistory
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; } = string.Empty;
        public DateTime? PickedUpDate { get; set; }
        public Guid BuyerVehicleId { get; set; }

        public virtual BuyerVehicle BuyerVehicle { get; set; } = default!;
    }
}
