namespace LynnEngraving.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string Status { get; set; } = "Submitted";
        public string? DesignSketchPath { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
