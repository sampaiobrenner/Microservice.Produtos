@ECHO OFF
SET /P migrationName=Digite o nome do migration: 

CD %CD%
CALL dotnet ef migrations add "%migrationName%" -s "Microservice.Produtos.WebApi\Microservice.Produtos.WebApi.csproj" -p "Microservice.Produtos.Repositories\Microservice.Produtos.Repositories.csproj" -v

PAUSE