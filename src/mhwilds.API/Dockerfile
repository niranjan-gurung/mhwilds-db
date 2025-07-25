# this stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# this stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["mhwilds.API/mhwilds.API.csproj", "mhwilds.API/"]
COPY ["mhwilds.Application/mhwilds.Application.csproj", "mhwilds.Application/"]
COPY ["mhwilds.Domain/mhwilds.Domain.csproj", "mhwilds.Domain/"]
COPY ["mhwilds.Infrastructure/mhwilds.Infrastructure.csproj", "mhwilds.Infrastructure/"]

# restore dependencies
RUN dotnet restore "./mhwilds.API/mhwilds.API.csproj"

COPY . .

# build app
WORKDIR "/src/mhwilds.API"
RUN dotnet build "./mhwilds.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# this stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./mhwilds.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# this stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mhwilds.API.dll"]