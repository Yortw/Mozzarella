@echo off
echo Press any key to publish
pause
"..\.nuget\NuGet.exe" push Mozzarella.2.0.2.nupkg -Source https://api.nuget.org/v3/index.json
pause