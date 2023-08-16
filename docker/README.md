# notes-containers / docker

- [Documentación](#documentación)
- [Instalación](#instalación)
- [Comandos](#comandos)

---

## Documentación

- [Get-Started Docker](https://docs.docker.com/get-started/)
- [Get-Started Docker Desktop](https://docs.docker.com/get-started/hands-on-overview)
- [Docker command line](https://docs.docker.com/engine/reference/commandline/cli)
- [DOCKER De NOVATO a PRO!, Pelado Nerd, 1 hora](https://www.youtube.com/watch?v=CV_Uf3Dq-EU)

## Instalación

- habilitar docker linux [wsl](https://learn.microsoft.com/en-us/windows/wsl/install)
  - ejecutar `wsl --install`
  - reiniciar
  - establecer usuario y contraseña para wsl
- habilitar docker windows [windowscontainers](https://learn.microsoft.com/en-us/virtualization/windowscontainers/quick-start/set-up-environment)
  - ejecutar `Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All`
- instalar [docker](https://docs.docker.com/desktop/install/windows-install)
  - descartar [Docker Desktop Installer.exe](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe)
  - ejecutar `Docker Desktop Installer.exe`
  - reiniciar

## Comandos

```powershell
# listar imagenes
docker images

# listar contenedores
docker ps

# obtener imagen
docker pull <REPOSITORY>:<TAG>

  docker pull mcr.microsoft.com/dotnet/samples:dotnetapp # .NET console sample
  docker pull mcr.microsoft.com/dotnet/samples:aspnetapp # ASP.NET web sample linux
  docker pull mcr.microsoft.com/dotnet/samples:dotnetapp-nanoserver-ltsc2022 # .NET console sample windows
  docker pull mcr.microsoft.com/dotnet/samples:aspnetapp-nanoserver-ltsc2022 # ASP.NET web sample windows

# ejecutar imagen
docker run PUERTO:PUERTO <REPOSITORY>:<TAG>
  # --rm = remove container when it exits
  # --publish = publish container ports to host
  # --detach = run container in background

  docker run --rm mcr.microsoft.com/dotnet/samples:dotnetapp # .NET console sample linux
  docker run --rm --publish 8000:80 mcr.microsoft.com/dotnet/samples:aspnetapp # ASP.NET web sample linux
  docker run --rm mcr.microsoft.com/dotnet/samples:dotnetapp-nanoserver-ltsc2022 # .NET console sample windows
  docker run --rm --publish 8000:80 mcr.microsoft.com/dotnet/samples:aspnetapp-nanoserver-ltsc2022 # ASP.NET web sample windows

# eliminar imagen
docker image rm <REPOSITORY>:<TAG>
  docker image rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker image rm mcr.microsoft.com/dotnet/samples:aspnetapp
```

```powershell
# construir imagen
docker build --tag <REPOSITORY>:<TAG> .

  docker build --tag lusalas16/welcome-to-docker:latest .

# publicar imagen
docker push <REPOSITORY>:<TAG>

  docker push lusalas16/welcome-to-docker:latest
```
