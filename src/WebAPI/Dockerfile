FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WebAPI/Rommanel.WebAPI.csproj src/WebAPI/
COPY src/Core/Application/Rommanel.Application.csproj src/Core/Application/
COPY src/Core/Domain/Rommanel.Domain.csproj src/Core/Domain/
COPY src/Infrastructure/Rommanel.Infrastructure.csproj src/Infrastructure/

RUN dotnet restore src/WebAPI/Rommanel.WebAPI.csproj

COPY src/ src/

WORKDIR /src/WebAPI

RUN ls -la

RUN dotnet build Rommanel.WebAPI.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/WebAPI/Rommanel.WebAPI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rommanel.WebAPI.dll"]