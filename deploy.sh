#!/bin/bash
set -e
REPO_URL="https://github.com/<YOUR-USERNAME>/lynns-engraving.git"
BRANCH="gh-pages"
BUILD_DIR="build"
echo "🧱 Building Lynn's Engraving Kiosk..."
dotnet publish src/Kiosk -c Release -o $BUILD_DIR
echo "⚙️ Preparing build for GitHub Pages..."
cd $BUILD_DIR
[ -d ".git" ] && rm -rf .git
git init
git add .
git commit -m "🚀 Deploy Lynn's Engraving v1.3"
git branch -M main
git remote add origin $REPO_URL
git push -f origin main:$BRANCH
echo "✅ Deployment complete! Visit: https://<YOUR-USERNAME>.github.io/Kiosk/"