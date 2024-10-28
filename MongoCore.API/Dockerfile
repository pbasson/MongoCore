FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://*:5076
ENV ASPNETCORE_ENVIRONMENT=Development
# ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
ARG PROJECT=MongoCore.API.csproj

WORKDIR /src
COPY . .

WORKDIR /src/MongoCore.API
RUN dotnet restore "$PROJECT"
RUN dotnet build "$PROJECT" -c $configuration -o /app/build

FROM build AS publish
RUN dotnet publish "$PROJECT" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
EXPOSE 5076

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoCore.API.dll"]
