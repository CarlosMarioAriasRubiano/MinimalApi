namespace MinimalApi.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }
    }
}
