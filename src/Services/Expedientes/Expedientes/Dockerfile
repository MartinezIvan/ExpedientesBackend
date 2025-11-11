# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos sln y csproj para restore por capas
COPY src/Services/Expedientes/Expedientes/Expedientes.csproj src/Services/Expedientes/Expedientes/
COPY src/Services/Expedientes/Expedientes.Domain/Expedientes.Domain.csproj src/Services/Expedientes/Expedientes.Domain/
COPY src/Services/Expedientes/Expedientes.Repository/Expedientes.Repository.csproj src/Services/Expedientes/Expedientes.Repository/

COPY src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj src/BuildingBlocks/BuildingBlocks/

# Restore
RUN dotnet restore src/Services/Expedientes/Expedientes/Expedientes.csproj

# Copiamos el resto del código
COPY . .

# Publish
RUN dotnet publish src/Services/Expedientes/Expedientes/Expedientes.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Expedientes.dll"]