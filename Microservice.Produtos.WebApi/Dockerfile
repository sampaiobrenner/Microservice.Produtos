#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservice.Produtos.WebApi/Microservice.Produtos.WebApi.csproj", "Microservice.Produtos.WebApi/"]
COPY ["Microservice.Produtos.Services/Microservice.Produtos.Services.csproj", "Microservice.Produtos.Services/"]
COPY ["Microservice.Produtos.Repositories/Microservice.Produtos.Repositories.csproj", "Microservice.Produtos.Repositories/"]
COPY ["Microservice.Produtos.Entities/Microservice.Produtos.Entities.csproj", "Microservice.Produtos.Entities/"]
RUN dotnet restore "Microservice.Produtos.WebApi/Microservice.Produtos.WebApi.csproj"
COPY . .
WORKDIR "/src/Microservice.Produtos.WebApi"
RUN dotnet build "Microservice.Produtos.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Produtos.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Produtos.WebApi.dll"]