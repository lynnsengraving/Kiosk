namespace LynnEngraving.Api.Models
{
    public class NotificationLog
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Channel { get; set; } = "email";
        public string Recipient { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
