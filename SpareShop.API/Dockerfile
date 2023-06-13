FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SpareShop.API/SpareShop.API.csproj", "SpareShop.API/"]
RUN dotnet restore "SpareShop.API/SpareShop.API.csproj"
COPY . .
WORKDIR "/src/SpareShop.API"
RUN dotnet build "SpareShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpareShop.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpareShop.API.dll"]
