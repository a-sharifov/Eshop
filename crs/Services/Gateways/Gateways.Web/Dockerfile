#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["crs/Services/Gateways/Eshop.Gateways.Web/Eshop.Gateways.Web.csproj", "crs/Services/Gateways/Eshop.Gateways.Web/"]
RUN dotnet restore "./crs/Services/Gateways/Eshop.Gateways.Web/./Eshop.Gateways.Web.csproj"
COPY . .
WORKDIR "/src/crs/Services/Gateways/Eshop.Gateways.Web"
RUN dotnet build "./Eshop.Gateways.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Eshop.Gateways.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./Eshop.Gateways.Web"]