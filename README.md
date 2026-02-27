<div align="center">

<h1>
  <br/>
  <br/>
  <div>🌽</div>
  <b>Hackathon</b>
  <br/>
  <br/>
  <br/>
</h1>

A **AgroSolutions** é uma cooperativa agrícola tradicional que busca se modernizar
para enfrentar os desafios do século XXI: otimização de recursos hídricos, aumento
da produtividade e sustentabilidade. Atualmente, a tomada de decisão no campo é
baseada majoritariamente na experiência dos agricultores, sem um forte apoio de
dados em tempo real, o que leva a desperdícios e a uma produtividade abaixo do
potencial. A aplicação conta com arquitetura Domain-Driven Design (DDD), ASP.NET Core 8, autenticação via JWT e banco de dados SQL Server + MongoDB, além de contar uma boas práticas de arquitetura, segurança e escalabilidade com Kubernetes.

</div>

> \[!NOTE]
>
> Este projeto visa oferecer uma aplicação robusta, escalável e segura. O desenvolvimento deste projeto é baseado exclusivamente nas suas necessidades guiadas pelo curso de pós graduação Fiap.

<div align="center">

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat&logo=mongodb&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-512BD4?style=flat&logo=.net&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=flat&logo=jsonwebtokens&logoColor=white)
![DDD](https://img.shields.io/badge/DDD-Domain--Driven%20Design-FF6B6B?style=flat)

</div>

<details>

<summary>
  <b>Table of contents</b>
</summary>

#### TOC

- [📦 Começando](#-começando)
- [🖱️ Primeiro acesso](#️-primeiro-acesso)
- [🚧 Contruindo e publicando a aplicação](#-contruindo-e-publicando-a-aplicação)
- [✨ Características](#-características)
- [🚀 Recursos](#-recursos)

####

</details>

## 📦 Começando

Comece clonando o repositório `hackathon-sensors`, executando o comando:

```bash
git clone https://github.com/andersonsrocha/hackathon-sensors.git
```

Agora acesse o projeto usando:

```bash
cd hackathon-sensors
```

Atualize as configurações do RabbitMQ, Id do talhão e delay de execução em `appsettings.json` e realize a restauração dos pacotes:

```bash
dotnet restore
```

Dentro da pasta `src`, execute o comando abaixo para iniciar a aplicação:

```bash
dotnet run -p HackathonSensors.WorkerService
```

E por fim o serviço estará ativo coletando e enviando os dados para a aplicação de de análise de dados.

## 🚧 Contruindo e publicando a aplicação

Agora para construirmos a aplicação, basta executar o comando abaixo no diretório raiz do projeto:

```bash
dotnet build
```

E por fim, para publicar a aplicação:

> \[!TIP]
>
> É possível trocar a pasta de destino substituindo `./publish` pelo diretório desejado.

```bash
dotnet publish -c Release -o ./publish
```

## ✨ Características

- [x] ~~Usuário admin.~~
- [x] ~~Banco de dados.~~
- [x] ~~Login com autenticação JWT.~~
- [x] ~~Funções admin e user.~~
- [x] ~~Testes unitários.~~
  - [x] ~~Validação de senha.~~
  - [x] ~~Validação de e-mail.~~
  - [x] ~~Autenticação.~~
  - [x] ~~Criação de usuário.~~
- [x] ~~Criação de arquivo Dockerfile.~~
- [x] ~~Domain-Driven Design.~~
- [x] ~~Criação de usuário.~~
- [x] ~~Criação de propriedades.~~
- [x] ~~Criação de talhões.~~
- [x] ~~Tratamento de dados.~~
- [x] ~~Mensageria.~~
- [x] ~~Sensores.~~
- [x] ~~Criação de migrations.~~
- [x] ~~Pipeline de CI/CD~~

<br/>

## 🚀 Recursos

- 🎨 **.NET 8 SDK**: Framework moderno e multiplataforma da Microsoft que oferece alta performance, suporte nativo para contêineres, APIs mínimas e recursos avançados de desenvolvimento. Inclui melhorias significativas em performance, garbage collection otimizado e suporte completo para desenvolvimento de aplicações web robustas e escaláveis.
- 🗄️ **SQL Server**: Sistema de gerenciamento de banco de dados relacional da Microsoft, conhecido por sua robustez, escalabilidade e integração nativa com o ecossistema .NET. Oferece recursos avançados como JSON nativo, transações ACID, alta disponibilidade e ferramentas de análise de performance.
- 🧪 **xUnit**: Framework de testes unitários para .NET que fornece uma base sólida para testes automatizados, com suporte para testes parametrizados, fixtures e execução paralela.
- 🐳 **Docker**: Containerização da aplicação para garantir consistência entre ambientes de desenvolvimento, teste e produção, facilitando deploy e escalabilidade.
- 🔐 **JWT Authentication**: Sistema de autenticação baseado em tokens seguros e stateless, permitindo autorização distribuída e controle de acesso granular.
- 🏗️ **Domain-Driven Design (DDD)**: Arquitetura que foca no domínio do negócio, promovendo código mais organizando, manutenível e alinhado com as regras de negócio.

<br/>

Copyright © 2026.
