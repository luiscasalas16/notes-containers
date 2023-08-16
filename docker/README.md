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
- verificar
  - `wsl --status`
    - Default Distribution: Ubuntu
    - Default Version: 2
  - `wsl --version`
    - WSL version: 1.2.5.0
    - Kernel version: 5.15.90.1
    - Windows version: 10.0.22621.1848

## Comandos

```powershell
# listar imagenes
docker images

# obtener imagen
docker pull <REPOSITORY>:<TAG>
  docker pull mcr.microsoft.com/dotnet/samples:dotnetapp
  docker pull mcr.microsoft.com/dotnet/samples:aspnetapp

# ejecutar imagen
docker run PUERTO:PUERTO <REPOSITORY>:<TAG>
  # --rm = remove container when it exits
  # --publish = publish container ports to host
  # --detach = run container in background
  docker run --rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker run --detach --rm --publish 8000:80 mcr.microsoft.com/dotnet/samples:aspnetapp

# eliminar imagen
docker image rm <REPOSITORY>:<TAG>
  docker image rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker image rm mcr.microsoft.com/dotnet/samples:aspnetapp
```

```powershell
# listar contenedores
docker ps

# inciar contenedor
docker start <ID>
  docker start e06f374c7f2d

# detener contenedor
docker stop <ID>
  docker stop e06f374c7f2d

# ver logs de contenedor
docker logs <ID>
  # --follow = continue follow the new output from the container
  docker logs e06f374c7f2d
```

```powershell
# construir imagen
docker build --tag <REPOSITORY>:<TAG> .
  docker build --tag lusalas16/welcome-to-docker:latest .

# publicar imagen
docker push <REPOSITORY>:<TAG>
  docker push lusalas16/welcome-to-docker:latest
```
