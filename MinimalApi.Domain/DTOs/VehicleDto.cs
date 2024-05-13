namespace MinimalApi.Domain.DTOs
{
    public class VehicleDto
    {
        public int Year { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SubModel { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string BuyerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
