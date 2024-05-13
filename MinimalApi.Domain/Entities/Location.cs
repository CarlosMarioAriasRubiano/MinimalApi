namespace MinimalApi.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ZipCode { get; set; }

        public virtual IEnumerable<Vehicle> Vehicles { get; set; } = default!;
    }
}
