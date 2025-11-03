using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace LynnEngraving.Api.Services
{
    public class NotificationService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IConfiguration config, ILogger<NotificationService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendSmsAsync(string to, string message)
        {
            try
            {
                TwilioClient.Init(_config["TWILIO_ACCOUNT_SID"], _config["TWILIO_AUTH_TOKEN"]);
                await MessageResource.CreateAsync(
                    body: message,
                    from: new Twilio.Types.PhoneNumber(_config["TWILIO_PHONE_NUMBER"]),
                    to: new Twilio.Types.PhoneNumber(to));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Twilio SMS failed");
                throw;
            }
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var client = new SendGridClient(_config["SENDGRID_API_KEY"]);
                var msg = new SendGridMessage
                {
                    From = new EmailAddress(_config["FROM_EMAIL"] ?? "no-reply@lynnsengraving.com", "Lynn's Engraving"),
                    Subject = subject,
                    PlainTextContent = body
                };
                msg.AddTo(new EmailAddress(to));
                await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SendGrid email failed");
                throw;
            }
        }
    }
}
