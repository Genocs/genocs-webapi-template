#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src


COPY ["NuGet.config", "."]
COPY ["src/Genocs.WebApiTemplate.WebApi/Genocs.WebApiTemplate.WebApi.csproj", "src/Genocs.WebApiTemplate.WebApi/"]
COPY ["src/Genocs.WebApiTemplate.Domain/Genocs.WebApiTemplate.Domain.csproj", "src/Genocs.WebApiTemplate.Domain/"]
COPY ["src/Genocs.WebApiTemplate.Contracts/Genocs.WebApiTemplate.Contracts.csproj", "src/Genocs.WebApiTemplate.Contracts/"]
COPY ["src/Genocs.WebApiTemplate.Infrastructure/Genocs.WebApiTemplate.Infrastructure.csproj", "src/Genocs.WebApiTemplate.Infrastructure/"]
RUN dotnet restore "src/Genocs.WebApiTemplate.WebApi/Genocs.WebApiTemplate.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Genocs.WebApiTemplate.WebApi"
RUN dotnet build "Genocs.WebApiTemplate.WebApi.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "Genocs.WebApiTemplate.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Genocs.WebApiTemplate.WebApi.dll"]
