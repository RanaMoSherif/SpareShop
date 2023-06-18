FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BestAuto.API/BestAuto.API.csproj", "BestAuto.API/"]
RUN dotnet restore "BestAuto.API/BestAuto.API.csproj"
COPY . .
WORKDIR "/src/BestAuto.API"
RUN dotnet build "BestAuto.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BestAuto.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BestAuto.API.dll"]
