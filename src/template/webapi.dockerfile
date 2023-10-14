#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src


COPY ["NuGet.config", "."]
COPY ["src/Genocs.Library.Template.WebApi/Genocs.Library.Template.WebApi.csproj", "src/Genocs.Library.Template.WebApi/"]
COPY ["src/Genocs.Library.Template.Domain/Genocs.Library.Template.Domain.csproj", "src/Genocs.Library.Template.Domain/"]
COPY ["src/Genocs.Library.Template.Contracts/Genocs.Library.Template.Contracts.csproj", "src/Genocs.Library.Template.Contracts/"]
COPY ["src/Genocs.Library.Template.Infrastructure/Genocs.Library.Template.Infrastructure.csproj", "src/Genocs.Library.Template.Infrastructure/"]
RUN dotnet restore "src/Genocs.Library.Template.WebApi/Genocs.Library.Template.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Genocs.Library.Template.WebApi"
RUN dotnet build "Genocs.Library.Template.WebApi.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "Genocs.Library.Template.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Genocs.Library.Template.WebApi.dll"]
