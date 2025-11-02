#!/usr/bin/env bash
curl -X POST http://localhost:5001/api/notify   -H "Content-Type: application/json"   -d '{"type":"OrderUpdate","orderId":1,"status":"completed","contact":{"phone":"+16055551234","email":"john@demo.com"}}'
