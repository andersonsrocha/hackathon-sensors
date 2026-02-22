FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

# Copiar arquivos de projeto para melhor cache do Docker
COPY HackathonSensors.sln ./
COPY src/HackathonSensors.Application/HackathonSensors.Application.csproj src/HackathonSensors.Application/
COPY src/HackathonSensors.WorkerService/HackathonSensors.WorkerService.csproj src/HackathonSensors.WorkerService/

# Copiar arquivos
COPY src/ src/

# Publicar o projeto
RUN dotnet publish src/HackathonSensors.WorkerService/HackathonSensors.WorkerService.csproj -c Release -o /app/publish

# Runtime stage - usando Alpine para imagem mais leve
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime

WORKDIR /app

# Criar non-root user (Alpine Linux)
RUN addgroup -S appuser && adduser -S appuser -G appuser

# Copiar os arquivos publicados
COPY --from=build /app/publish .

# Trocar ownership para non-root user
RUN chown -R appuser:appuser /app
USER appuser

ENTRYPOINT ["dotnet", "HackathonSensors.WorkerService.dll"]