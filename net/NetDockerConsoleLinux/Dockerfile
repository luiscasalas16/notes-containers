#NetDockerConsoleLinux

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NetDockerConsoleLinux/NetDockerConsoleLinux.csproj", "NetDockerConsoleLinux/"]
RUN dotnet restore "NetDockerConsoleLinux/NetDockerConsoleLinux.csproj"
COPY . .
WORKDIR "/src/NetDockerConsoleLinux"
RUN dotnet build "NetDockerConsoleLinux.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetDockerConsoleLinux.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetDockerConsoleLinux.dll"]