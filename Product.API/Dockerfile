FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MicroservicesDemo/MicroservicesDemo.csproj", "MicroservicesDemo/"]
RUN dotnet restore "MicroservicesDemo/MicroservicesDemo.csproj"
COPY . .
WORKDIR "/src/MicroservicesDemo"
RUN dotnet build "MicroservicesDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesDemo.dll"]
