using Microsoft.AspNetCore.Mvc;
using LynnEngraving.Api.Services;

namespace LynnEngraving.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly NotificationService _notify;

        public NotifyController(NotificationService notify)
        {
            _notify = notify;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NotifyRequest req)
        {
            var status = req.Status?.ToLowerInvariant() ?? "submitted";
            var message = status switch
            {
                "inprogress" => $"Your order #{req.OrderId} is now being engraved!",
                "completed" => $"Your order #{req.OrderId} is ready for pickup.",
                _ => $"Thanks for your order #{req.OrderId}! We’ll notify you when it's ready."
            };

            if (!string.IsNullOrWhiteSpace(req.Contact?.Phone))
                await _notify.SendSmsAsync(req.Contact!.Phone!, message);

            if (!string.IsNullOrWhiteSpace(req.Contact?.Email))
                await _notify.SendEmailAsync(req.Contact!.Email!, "Lynn's Engraving Order Update", message);

            return Ok(new { success = true });
        }
    }

    public class NotifyRequest
    {
        public string? Type { get; set; }
        public int OrderId { get; set; }
        public string? Status { get; set; }
        public ContactInfo? Contact { get; set; }
    }

    public class ContactInfo
    {
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
