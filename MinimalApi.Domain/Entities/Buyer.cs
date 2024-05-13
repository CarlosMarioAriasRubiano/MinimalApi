namespace MinimalApi.Domain.Entities
{
    public class Buyer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual IEnumerable<BuyerVehicle> BuyerVehicles { get; set; } = default!;
    }
}
