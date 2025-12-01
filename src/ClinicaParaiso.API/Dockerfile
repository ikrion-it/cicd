# BASE RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# COPIA OS .CSPROJ PRIMEIRO (CAMINHOS CORRETOS)
COPY ClinicaParaiso.API/ClinicaParaiso.API.csproj ClinicaParaiso.API/
COPY ClinicaParaiso.Application/ClinicaParaiso.Application.csproj ClinicaParaiso.Application/
COPY ClinicaParaiso.Domain/ClinicaParaiso.Domain.csproj ClinicaParaiso.Domain/
COPY ClinicaParaiso.Persistence/ClinicaParaiso.Persistence.csproj ClinicaParaiso.Persistence/

# RESTORE
RUN dotnet restore ClinicaParaiso.API/ClinicaParaiso.API.csproj

# COPIA TUDO
COPY . .

# BUILD
WORKDIR /src/ClinicaParaiso.API
RUN dotnet build ClinicaParaiso.API.csproj -c $BUILD_CONFIGURATION -o /app/build

# PUBLISH
FROM build AS publish
RUN dotnet publish ClinicaParaiso.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FINAL IMAGE
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClinicaParaiso.API.dll"]