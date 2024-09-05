FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Models/Models.csproj", "Models/"]
COPY ["CrudProductsApiEF/CrudProductsApiEF.csproj", "CrudProductsApiEF/"]
RUN dotnet restore "CrudProductsApiEF/CrudProductsApiEF.csproj"

COPY . .
WORKDIR "/src/CrudProductsApiEF"
RUN dotnet build "CrudProductsApiEF.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CrudProductsApiEF.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudProductsApiEF.dll"]
