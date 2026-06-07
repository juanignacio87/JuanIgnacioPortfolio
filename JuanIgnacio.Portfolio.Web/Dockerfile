# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY JuanIgnacio.Portfolio.Web/JuanIgnacio.Portfolio.Web.csproj JuanIgnacio.Portfolio.Web/
RUN dotnet restore JuanIgnacio.Portfolio.Web/JuanIgnacio.Portfolio.Web.csproj

COPY JuanIgnacio.Portfolio.Web/ JuanIgnacio.Portfolio.Web/
WORKDIR /src/JuanIgnacio.Portfolio.Web
RUN dotnet publish JuanIgnacio.Portfolio.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JuanIgnacio.Portfolio.Web.dll"]
