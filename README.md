# Microservice.Produtos

[![CodeFactor](https://www.codefactor.io/repository/github/sampaiobrenner/microservice.produtos/badge?s=bcd6289dcff1bcd7e5cab16a405672f7d56e24c6)](https://www.codefactor.io/repository/github/sampaiobrenner/microservice.produtos)

Projeto de estudos em .NET Core 

- Estruturação de Projeto com derivação arquitetural DDD;
- Conhecendo o Dotnet CLI;
- Conhecendo o *.SLN e *.CSPROJ;
- Implementação de designs, tais como: Template Method, Strategy, Repository, dentre outros... 
- Fluent Validation;
- Auto Mapper;
- Entity Framework in Memory;
- Evoluindo API para alta disponibilidade com processamento assíncrono;
- Versionamento de API;
- Documentação de API's com Swagger;
- Serviço de Log utilizando ILogger e Log4Net;
- Tratar esgotamento de socket com IHttpClientFactory e respectivo design para clients;
- Resiliência com Polly e Refresh token with Polly-retry;
- Conhecendo conceitos e implementação de Autenticação e Autorização com JWT e .NET Core 3;

### Pré requisitos

Microsoft .NET Core 3.1

```
dotnet --version
```
For more details

```
dotnet --info
```


### Para executar o container e efetuar o build do projeto basta executar o comando abaixo na raiz do projeto:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build -d
```

###Para somente executar o container basta executar o comando abaixo na raiz do projeto:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

## Executando o sonar

```
SonarScanner.MSBuild.exe begin /k:"microservice-produtos" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="3cf8ccd2c00a498bc6b0f7a7ff69ad3661b403e7"

"D:\Arquivo de Programas\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MsBuild.exe" Microservice.Produtos.sln /t:Rebuild

SonarScanner.MSBuild.exe end /d:sonar.login="3cf8ccd2c00a498bc6b0f7a7ff69ad3661b403e7"
```


## Criar nova migration

```
Executar no Package manager console o comando: dotnet tool install --global dotnet-ef --version 3.0.0
Eecutar o "create migrations.bat" e digitar o nome da migration desejado.

```


## Built With

* [Microsoft .NET Core](https://dotnet.microsoft.com/)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/#pivot=efcore) 
* [Fluent Validation](https://fluentvalidation.net/) 
* [Auto Mapper](https://automapper.org/) 