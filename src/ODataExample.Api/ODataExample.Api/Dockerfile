#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ODataExample.Api/ODataExample.Api.csproj", "ODataExample.Api/"]
RUN dotnet restore "ODataExample.Api/ODataExample.Api.csproj"
COPY . .
WORKDIR "/src/ODataExample.Api"
RUN dotnet build "ODataExample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ODataExample.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ODataExample.Api.dll"]