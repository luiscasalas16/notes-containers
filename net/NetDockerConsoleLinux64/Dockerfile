#NetDockerConsoleLinux64

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NetDockerConsoleLinux64/NetDockerConsoleLinux64.csproj", "NetDockerConsoleLinux64/"]
RUN dotnet restore "NetDockerConsoleLinux64/NetDockerConsoleLinux64.csproj"
COPY . .
WORKDIR "/src/NetDockerConsoleLinux64"
RUN dotnet build "NetDockerConsoleLinux64.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetDockerConsoleLinux64.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetDockerConsoleLinux64.dll"]