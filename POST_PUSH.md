# POST_PUSH: GitHub Setup

1) Enable Actions: Settings → Actions → General → Allow all actions
2) Add Repository Secrets (Settings → Secrets → Actions):
- TWILIO_ACCOUNT_SID
- TWILIO_AUTH_TOKEN
- TWILIO_PHONE_NUMBER
- SENDGRID_API_KEY
- FROM_EMAIL
3) Push:
```bash
git init
git add .
git commit -m "Initial Lynn's Engraving kiosk v1.0"
git branch -M main
git remote add origin https://github.com/<username>/lynns-engraving.git
git push -u origin main
```
