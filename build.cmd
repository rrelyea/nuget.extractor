dotnet build -c Release
dotnet publish -c Release -r win7-x86 /p:PublishSingleFile=true /p:TargetFramework=net5.0 /p:PublishTrimmed=true