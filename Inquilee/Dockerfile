FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["/Inquilee.csproj", "Inquilee/"]
RUN dotnet restore "Inquilee/Inquilee.csproj"
COPY . .
WORKDIR "/src/Inquilee"
RUN dotnet build "Inquilee/Inquilee.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ".Inquilee/Inquilee.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["Inquilee/wwwroot/css/swaggerDark.css", "Inquilee/wwwroot/css/swaggerDark.css"]

RUN if [ -f .env ]; then cp .env /app/.env; fi

ENTRYPOINT ["dotnet", "Inquilee.dll"]
