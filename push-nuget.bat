dotnet pack -c Release
nuget push -Source https://api.nuget.org/v3/index.json bin\Release\*.nupkg