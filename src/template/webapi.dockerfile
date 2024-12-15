#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

COPY ["src/WebApi/WebApi.csproj", "WebApi/"]
COPY ["src/Domain/Domain.csproj", "Domain/"]
COPY ["src/Contracts/Contracts.csproj", "Contracts/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "Infrastructure/"]

COPY ["NuGet.config", "."]
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["Directory.Build.targets", "Directory.Build.targets"]
COPY ["stylecop.json", "stylecop.json"]
COPY ["launchSettings.json", "launchSettings.json"]
COPY ["global.json", "global.json"]


RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Genocs.Library.Template.WebApi.dll"]
