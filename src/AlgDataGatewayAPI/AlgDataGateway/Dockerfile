#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AlgDataGatewayAPI/AlgDataGateway/AlgDataGateway.csproj", "src/AlgDataGatewayAPI/AlgDataGateway/"]
COPY ["src/AlgorithmAPI.Client/AlgorithmAPI.Client.csproj", "src/AlgorithmAPI.Client/"]
RUN dotnet restore "src/AlgDataGatewayAPI/AlgDataGateway/AlgDataGateway.csproj"
COPY . .
WORKDIR "/src/src/AlgDataGatewayAPI/AlgDataGateway"
RUN dotnet build "AlgDataGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlgDataGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlgDataGateway.dll"]