#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["src/Genocs.Library.Template.Worker/Genocs.Library.Template.Worker.csproj", "src/Genocs.Library.Template.Worker/"]
COPY ["src/Genocs.Library.Template.Domain/Genocs.Library.Template.Domain.csproj", "src/Genocs.Library.Template.Domain/"]
COPY ["src/Genocs.Library.Template.Contracts/Genocs.Library.Template.Contracts.csproj", "src/Genocs.Library.Template.Contracts/"]
COPY ["src/Genocs.Library.Template.Infrastructure/Genocs.Library.Template.Infrastructure.csproj", "src/Genocs.Library.Template.Infrastructure/"]
RUN dotnet restore "src/Genocs.Library.Template.Worker/Genocs.Library.Template.Worker.csproj"
COPY . .
WORKDIR "/src/src/Genocs.Library.Template.Worker"
RUN dotnet build "Genocs.Library.Template.Worker.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "Genocs.Library.Template.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Genocs.Library.Template.Worker.dll"]