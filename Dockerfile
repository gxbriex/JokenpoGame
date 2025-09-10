FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY JokenpoGame.sln .
COPY src/JokenpoGame/JokenpoGame.csproj src/JokenpoGame/
COPY tests/JokenpoGame.Tests/JokenpoGame.Tests.csproj tests/JokenpoGame.Tests/
RUN dotnet restore "JokenpoGame.sln"  # Restore using the solution file to handle all projects

COPY . .
RUN dotnet publish "src/JokenpoGame/JokenpoGame.csproj" -c Release -o /app --no-restore  # Publish only the main app project

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "JokenpoGame.dll"]