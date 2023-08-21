#NetDockerConsoleWindows64

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NetDockerConsoleWindows64/NetDockerConsoleWindows64.csproj", "NetDockerConsoleWindows64/"]
RUN dotnet restore "NetDockerConsoleWindows64/NetDockerConsoleWindows64.csproj"
COPY . .
WORKDIR "/src/NetDockerConsoleWindows64"
RUN dotnet build "NetDockerConsoleWindows64.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetDockerConsoleWindows64.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetDockerConsoleWindows64.dll"]