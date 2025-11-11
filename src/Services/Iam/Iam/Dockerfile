# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos sln y csproj para restore por capas
COPY src/Services/Iam/Iam/Iam.csproj src/Services/Iam/Iam/
COPY src/Services/Iam/Iam.Domain/Iam.Domain.csproj src/Services/Iam/Iam.Domain/
COPY src/Services/Iam/Iam.Repository/Iam.Repository.csproj src/Services/Iam/Iam.Repository/
COPY src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj src/BuildingBlocks/BuildingBlocks/
# Restore
RUN dotnet restore src/Services/Iam/Iam/Iam.csproj

# Copiamos el resto del código
COPY . .

# Publish
RUN dotnet publish src/Services/Iam/Iam/Iam.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Iam.dll"]