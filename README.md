<div align="center">

<h1>
  <br/>
  <br/>
  <div>�</div>
  <b>Hackathon Sensors</b>
  <br/>
  <br/>
  <br/>
</h1>

Sistema de coleta de dados de sensores IoT para monitoramento agrícola da **AgroSolutions**,
uma cooperativa que busca se modernizar através da Internet das Coisas (IoT). O sistema
coleta automaticamente dados de sensores como umidade do solo, temperatura ambiente
e precipitação, enviando essas informações via mensageria RabbitMQ para análise
em tempo real. A aplicação é um Worker Service desenvolvido em .NET 8 com
containerização Docker e orquestração Kubernetes para escalabilidade.

</div>

> \[!NOTE]
>
> Este projeto visa oferecer uma aplicação robusta, escalável e segura. O desenvolvimento deste projeto é baseado exclusivamente nas suas necessidades guiadas pelo curso de pós graduação Fiap.

<div align="center">

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![RabbitMQ](https://img.shields.io/badge/RabbitMQ-FF6600?style=flat&logo=rabbitmq&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![Kubernetes](https://img.shields.io/badge/Kubernetes-326ce5?style=flat&logo=kubernetes&logoColor=white)
![IoT](https://img.shields.io/badge/IoT-Sensors-00D4AA?style=flat&logo=internetofthings&logoColor=white)
![Worker Service](https://img.shields.io/badge/Worker%20Service-Background-512BD4?style=flat&logo=.net&logoColor=white)

</div>

<details>

<summary>
  <b>Table of contents</b>
</summary>

#### TOC

- [📦 Começando](#-começando)
- [� Monitoramento](#-monitoramento)
- [🚧 Construindo e publicando a aplicação](#-construindo-e-publicando-a-aplicação)
- [✨ Características](#-características)
- [🚀 Recursos](#-recursos)

####

</details>

## 📦 Começando

### Pré-requisitos

- [**.NET 8 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0) - Framework de desenvolvimento
- **RabbitMQ** - Sistema de mensageria (pode ser Docker ou instalação local)
- **Docker** (opcional) - Para containerização e RabbitMQ

### Instalação

Comece clonando o repositório `hackathon-sensors`, executando o comando:

```bash
git clone https://github.com/andersonsrocha/hackathon-sensors.git
```

Agora acesse o projeto usando:

```bash
cd hackathon-sensors
```

Realize a restauração dos pacotes:

```bash
dotnet restore
```

Configure o RabbitMQ localmente (necessário para o funcionamento):

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 \
  -e RABBITMQ_DEFAULT_USER=admin \
  -e RABBITMQ_DEFAULT_PASS=admin123 \
  rabbitmq:3-management
```

Agora execute o comando abaixo para iniciar o Worker Service:

```bash
dotnet run --project src/HackathonSensors.WorkerService
```

O serviço começará a coletar dados de sensores simulados e enviá-los para a fila RabbitMQ a cada 60 segundos.

<br/>

## 📊 Monitoramento

### Interface Web RabbitMQ

Para monitorar a fila RabbitMQ e os dados sendo coletados:

**URL:** http://localhost:15672

**Credenciais:**

```bash
Usuário: admin
Senha: admin123
```

### Configuração do Sensor

Os sensores podem ser configurados no `appsettings.json`:

```json
{
  "PlotId": "73df2149-4b7a-482f-aede-b928aac66842",
  "DelayInSeconds": 60,
  "RabbitMQ": {
    "HostName": "localhost",
    "UserName": "admin",
    "Password": "admin123",
    "QueueName": "sensor.readings"
  }
}
```

### Dados Coletados

**Parâmetros monitorados:**

- 🌡️ **Temperatura**: 15-35°C (simulado)
- 💧 **Umidade do Solo**: 0-100% (simulado)
- ☔ **Precipitação**: 0-10mm (simulado)
- 📅 **Data/Hora**: Timestamp de cada leitura
- 🗺️ **Plot ID**: Identificador do talhão monitorado

**Intervalo de coleta:** Configurável (padrão: 60 segundos)
**Fila RabbitMQ:** `sensor.readings`

## 🚧 Construindo e publicando a aplicação

Para construir a aplicação, execute o comando abaixo no diretório raiz do projeto:

```bash
dotnet build
```

Para publicar o Worker Service:

> \[!TIP]
>
> É possível trocar a pasta de destino substituindo `./publish` pelo diretório desejado.

```bash
dotnet publish -c Release -o ./publish --project src/HackathonSensors.WorkerService
```

### 🐳 Docker

Para criar a imagem Docker:

```bash
docker build -t hackathon-sensors .
```

Para executar via Docker:

```bash
docker run -d --name sensor-worker \
  -e PlotId="73df2149-4b7a-482f-aede-b928aac66842" \
  -e DelayInSeconds="60" \
  -e RabbitMQ__HostName="host.docker.internal" \
  hackathon-sensors
```

### ☸️ Kubernetes

Para fazer deploy no Kubernetes:

```bash
kubectl apply -f manifests/
```

## ✨ Características

- [x] ~~Coleta automatizada de dados de sensores IoT~~
- [x] ~~Worker Service para processamento em background~~
- [x] ~~Integração com RabbitMQ para mensageria~~
- [x] ~~Simulação de sensores agrícolas realista~~
- [x] ~~Monitoramento de umidade do solo~~
- [x] ~~Monitoramento de temperatura ambiente~~
- [x] ~~Monitoramento de precipitação~~
- [x] ~~Configuração flexível por talhão (PlotId)~~
- [x] ~~Intervalos de coleta configuráveis~~
- [x] ~~Containerização com Docker~~
- [x] ~~Deploy em Kubernetes com manifests~~
- [x] ~~Auto-scaling via HPA (Horizontal Pod Autoscaler)~~
- [x] ~~Logs estruturados para monitoramento~~
- [x] ~~Arquitetura de microserviços preparada~~

<br/>

## 🚀 Recursos

- 🎨 **.NET 8 SDK**: Framework moderno e multiplataforma otimizado para Worker Services e processamento em background. Oferece alta performance para coleta contínua de dados IoT com garbage collection otimizado.
- 🐰 **RabbitMQ**: Sistema de mensageria robusto e confiável para comunicação assíncrona entre microserviços. Garante entrega confiável dos dados coletados pelos sensores mesmo em cenários de alta disponibilidade.
- ⚙️ **Worker Service**: Serviço de background .NET especializado para coleta contínua de dados de sensores, executando de forma independente e resiliente com logging estruturado.
- 🌾 **IoT Sensor Simulation**: Simulador avançado de sensores agrícolas que gera dados realistas de umidade do solo, temperatura e precipitação, permitindo testes sem hardware físico.
- 🐳 **Docker**: Containerização completa da aplicação para garantir consistência entre ambientes e facilitar deploy de sensores distribuídos em diferentes localidades.
- ☸️ **Kubernetes**: Orquestração de contêineres com manifests completos incluindo Deployment, Service, ConfigMap e HPA para auto-scaling baseado na carga de trabalho dos sensores.
- 📊 **Structured Logging**: Sistema de logs estruturados com diferentes níveis para monitoramento eficaz da coleta de dados e troubleshooting de sensores em campo.
- 🔧 **Configuration Management**: Sistema flexível de configuração permitindo ajustes de PlotId, intervalos de coleta e conexões RabbitMQ sem necessidade de redeployment.

## 🌱 Como Funciona o Sistema

### Arquitetura IoT

O sistema é composto por um **Worker Service** que simula sensores IoT distribuídos em talhões agrícolas. Cada sensor coleta dados ambientais críticos e os transmite via mensageria para processamento.

```mermaid
graph LR
    A[Sensores IoT] --> B[Worker Service]
    B --> C[RabbitMQ Queue]
    C --> D[Processamento]
    D --> E[Análise de Dados]
```

### Fluxo de Dados

1. **Coleta Automática**: Worker Service executa em loop contínuo
2. **Simulação Realista**: Gera dados baseados em padrões agrícolas reais
3. **Transmissão Segura**: Envia dados via RabbitMQ com garantia de entrega
4. **Identificação**: Cada leitura vinculada a um PlotId específico
5. **Timestamping**: Registro preciso de data/hora para análise temporal

### Dados de Sensor (JSON)

```json
{
  "plotId": "73df2149-4b7a-482f-aede-b928aac66842",
  "date": "2026-02-27T10:30:00Z",
  "soilMoisture": 65.4,
  "temperature": 24.8,
  "precipitation": 2.1
}
```

### Escalabilidade

- **Múltiplos Sensores**: Deploy independente por talhão
- **Kubernetes HPA**: Auto-scaling baseado em carga
- **Configuração Flexível**: Ajuste de intervalos por ambiente
- **Tolerância a Falhas**: Recuperação automática de conexão

<br/>

Copyright © 2026.
