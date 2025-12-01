# BASE RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# COPIA OS .CSPROJ PRIMEIRO (CAMINHOS CORRETOS)
COPY src/ClinicaParaiso.API/ClinicaParaiso.API.csproj ClinicaParaiso.API/
COPY src/ClinicaParaiso.Application/ClinicaParaiso.Application.csproj ClinicaParaiso.Application/
COPY src/ClinicaParaiso.Domain/ClinicaParaiso.Domain.csproj ClinicaParaiso.Domain/
COPY src/ClinicaParaiso.Persistence/ClinicaParaiso.Persistence.csproj ClinicaParaiso.Persistence/

# RESTORE
RUN dotnet restore ClinicaParaiso.API/ClinicaParaiso.API.csproj

# COPIA TUDO
COPY . .

# BUILD & PUBLISH
# Altera o diretório para onde o projeto .csproj da API está
WORKDIR /src/ClinicaParaiso.API

# Publica os artefatos finais para /app/publish no CONTAINER.
RUN dotnet publish ClinicaParaiso.API.csproj -c $BUILD_CONFIGURATION -o /app/publish

# FINAL IMAGE
FROM base AS final
WORKDIR /app
# Copia o resultado do 'publish' feito no estágio BUILD
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ClinicaParaiso.API.dll"]