namespace MinimalApi.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double Balance { get; set; }

        public virtual IEnumerable<Vehicle> Vehicles { get; set; } = default!;
    }
}
