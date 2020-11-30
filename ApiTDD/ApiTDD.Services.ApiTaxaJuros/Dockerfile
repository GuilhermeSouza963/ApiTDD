FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApiTDD.Services.ApiTaxaJuros.csproj", "ApiTDD.Services.ApiTaxaJuros/"]
RUN dotnet restore "ApiTDD.Services.ApiTaxaJuros/ApiTDD.Services.ApiTaxaJuros.csproj"
COPY . .
WORKDIR "/src/ApiTDD.Services.ApiTaxaJuros"
RUN dotnet build "ApiTDD.Services.ApiTaxaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTDD.Services.ApiTaxaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTDD.Services.ApiTaxaJuros.dll"]