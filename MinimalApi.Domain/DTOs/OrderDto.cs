namespace MinimalApi.Domain.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }
    }
}
