Write-Host "[1/3] Restoring .NET packages..."
dotnet restore

Write-Host "[2/3] Starting API on http://localhost:5001 ..."
Start-Process -FilePath "dotnet" -ArgumentList "run --urls http://localhost:5001" -WorkingDirectory "src/LynnEngraving.Api"

Start-Sleep -Seconds 3

Write-Host "[3/3] Starting Kiosk on http://localhost:5000 ..."
Start-Process -FilePath "dotnet" -ArgumentList "run --urls http://localhost:5000" -WorkingDirectory "src/LynnEngraving.Kiosk"

Start-Sleep -Seconds 2
Start-Process "http://localhost:5000"
