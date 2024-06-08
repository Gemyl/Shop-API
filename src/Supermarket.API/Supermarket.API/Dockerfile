#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Supermarket.API/Supermarket.API.csproj", "Supermarket.API/"]
COPY ["Supermarket.Commands/Supermarket.Commands.csproj", "Supermarket.Commands/"]
COPY ["Supermarket.Entities/Supermarket.Core.csproj", "Supermarket.Entities/"]
COPY ["Supermarket.Handlers/Supermarket.Handlers.csproj", "Supermarket.Handlers/"]
COPY ["Supermarket.Mapping/Supermarket.Mapping.csproj", "Supermarket.Mapping/"]
COPY ["Supermarket.Extensions/Supermarket.Extensions.csproj", "Supermarket.Extensions/"]
COPY ["Supermarket.Queries/Supermarket.Queries.csproj", "Supermarket.Queries/"]
COPY ["Supermarket.Persistence/Supermarket.Persistence.csproj", "Supermarket.Persistence/"]
RUN dotnet restore "./Supermarket.API/Supermarket.API.csproj"
COPY . .
WORKDIR "/src/Supermarket.API"
RUN dotnet build "./Supermarket.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Supermarket.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Supermarket.API.dll"]