FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY src/JokenpoGame/JokenpoGame.csproj src/JokenpoGame/
RUN dotnet restore "src/JokenpoGame/JokenpoGame.csproj"

COPY . .
RUN dotnet publish "src/JokenpoGame/JokenpoGame.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "JokenpoGame.dll"]