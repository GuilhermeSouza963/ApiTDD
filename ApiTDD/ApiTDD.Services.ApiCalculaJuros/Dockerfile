#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApiTDD.Services.ApiCalculaJuros/ApiTDD.Services.ApiCalculaJuros.csproj", "ApiTDD.Services.ApiCalculaJuros/"]
RUN dotnet restore "ApiTDD.Services.ApiCalculaJuros/ApiTDD.Services.ApiCalculaJuros.csproj"
COPY . .
WORKDIR "/src/ApiTDD.Services.ApiCalculaJuros"
RUN dotnet build "ApiTDD.Services.ApiCalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTDD.Services.ApiCalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTDD.Services.ApiCalculaJuros.dll"]