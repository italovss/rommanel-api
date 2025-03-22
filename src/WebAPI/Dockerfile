# See https://aka.ms/customizecontainer
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WebAPI/Rommanel.WebAPI.csproj", "src/WebAPI/"]
COPY ["src/Infrastructure/Rommanel.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Core/Application/Rommanel.Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/Rommanel.Domain.csproj", "src/Core/Domain/"]
RUN dotnet restore "./src/WebAPI/Rommanel.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/WebAPI"
RUN dotnet build "./Rommanel.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rommanel.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rommanel.WebAPI.dll"]