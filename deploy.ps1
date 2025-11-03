# Windows deploy for Lynn's Engraving
$RepoUrl = "https://github.com/<YOUR-USERNAME>/lynns-engraving.git"
$Branch = "gh-pages"
$BuildDir = "build"
Write-Host "🧱 Building Lynn's Engraving Kiosk..."
dotnet publish .\src\Kiosk -c Release -o $BuildDir
Write-Host "⚙️ Preparing build for GitHub Pages..."
Set-Location $BuildDir
if (Test-Path ".git") { Remove-Item ".git" -Recurse -Force }
git init
git add .
git commit -m "🚀 Deploy Lynn's Engraving v1.3"
git branch -M main
git remote add origin $RepoUrl
git push -f origin main:$Branch
Write-Host "✅ Deployment complete! Visit: https://<YOUR-USERNAME>.github.io/Kiosk/"