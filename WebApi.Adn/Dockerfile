#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi.Adn/WebApi.Adn.csproj", "WebApi.Adn/"]
RUN dotnet restore "WebApi.Adn/WebApi.Adn.csproj"
COPY . .
WORKDIR "/src/WebApi.Adn"
RUN dotnet build "WebApi.Adn.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.Adn.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Adn.dll"]