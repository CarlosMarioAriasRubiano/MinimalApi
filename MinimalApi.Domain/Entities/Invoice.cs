namespace MinimalApi.Domain.Entities
{
    public class Invoice
    {
        public Guid CustomerId { get; set; }
        public double Total { get; set; }
    }
}
