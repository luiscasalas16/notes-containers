#NetDockerConsoleWindows32

FROM lusalas16/dotnet/runtime/x86:7.0.10-windowsservercore-ltsc2022 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NetDockerConsoleWindows32/NetDockerConsoleWindows32.csproj", "NetDockerConsoleWindows32/"]
RUN dotnet restore "NetDockerConsoleWindows32/NetDockerConsoleWindows32.csproj"
COPY . .
WORKDIR "/src/NetDockerConsoleWindows32"
RUN dotnet build "NetDockerConsoleWindows32.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetDockerConsoleWindows32.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetDockerConsoleWindows32.dll"]