#!/usr/bin/env bash
set -e

echo "[1/3] Restoring .NET packages..."
dotnet restore

echo "[2/3] Starting API on http://localhost:5001 ..."
( cd src/LynnEngraving.Api && dotnet run --urls http://localhost:5001 ) &
API_PID=$!

sleep 3

echo "[3/3] Starting Kiosk on http://localhost:5000 ..."
( cd src/LynnEngraving.Kiosk && dotnet run --urls http://localhost:5000 ) &
KIOSK_PID=$!

if command -v open &> /dev/null; then
  open http://localhost:5000
elif command -v xdg-open &> /dev/null; then
  xdg-open http://localhost:5000
fi

echo "API PID: $API_PID, KIOSK PID: $KIOSK_PID"
wait
