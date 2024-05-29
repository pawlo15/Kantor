#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7070
EXPOSE 7071

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Kantor.Api/Kantor.Api.csproj", "Kantor.Api/"]
COPY ["Kantor.Core/Kantor.Core.csproj", "Kantor.Core/"]
COPY ["Kantor.Infrastructure/Kantor.Infrastructure.csproj", "Kantor.Infrastructure/"]
COPY ["Kantor.Shared/Kantor.Shared.csproj", "Kantor.Shared/"]
RUN dotnet restore "./Kantor.Api/Kantor.Api.csproj"
COPY . .
WORKDIR "/src/Kantor.Api"
RUN dotnet build "./Kantor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kantor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kantor.Api.dll"]