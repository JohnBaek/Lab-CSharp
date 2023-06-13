FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Scaffold.API.V1/Scaffold.API.V1.csproj", "Scaffold.API.V1/"]
RUN dotnet restore "Scaffold.API.V1/Scaffold.API.V1.csproj"
COPY . .
WORKDIR "/src/Scaffold.API.V1"
RUN dotnet build "Scaffold.API.V1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scaffold.API.V1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scaffold.API.V1.dll"]
