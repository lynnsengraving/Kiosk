# Lynn's Engraving Kiosk (v1.0)

Blazor Server kiosk + ASP.NET Core Web API with SQLite, Twilio (SMS), and SendGrid (email).

## QuickStart (macOS / Linux)

```bash
chmod +x setup.sh
./setup.sh
```

- Kiosk opens: http://localhost:5000
- API runs at: http://localhost:5001

## Test Notification

```bash
curl -X POST http://localhost:5001/api/notify   -H "Content-Type: application/json"   -d '{
    "type": "OrderUpdate",
    "orderId": 1,
    "status": "completed",
    "contact": { "phone": "+16055551234", "email": "john@demo.com" }
  }'
```

## Env Vars
```
TWILIO_ACCOUNT_SID=ACxxxxxxxx
TWILIO_AUTH_TOKEN=your_auth_token
TWILIO_PHONE_NUMBER=+15551234567
SENDGRID_API_KEY=SG.xxxxxxxx
FROM_EMAIL=no-reply@lynnsengraving.com
```
