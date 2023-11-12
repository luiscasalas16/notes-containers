# notes-containers / docker

- [Documentación](#documentación)
- [Instalación](#instalación)
- [Comandos](#comandos)

---

## Documentación

- [Get-Started Docker](https://docs.docker.com/get-started/)
- [Get-Started Docker Desktop](https://docs.docker.com/get-started/hands-on-overview)
- [Docker command line reference](https://docs.docker.com/engine/reference/commandline/cli/)
- [Docker dockerfile reference](https://docs.docker.com/engine/reference/builder/)
- [DOCKER De NOVATO a PRO!, Pelado Nerd, 1 hora](https://www.youtube.com/watch?v=CV_Uf3Dq-EU)
- [Docker cheat-sheet](https://devtalles.com/files/docker-cheat-sheet.pdf)

## Instalación

- habilitar docker linux [wsl](https://learn.microsoft.com/en-us/windows/wsl/install)
  - ejecutar `wsl --install`
  - reiniciar
  - establecer usuario y contraseña para wsl
- habilitar docker windows [windows containers](https://learn.microsoft.com/en-us/virtualization/windowscontainers/quick-start/set-up-environment)
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

### Imágenes

```powershell
# listar imágenes
docker image ls

# obtener imagen
docker pull <REPOSITORY>:<TAG>
  docker pull mcr.microsoft.com/dotnet/samples:dotnetapp
  docker pull mcr.microsoft.com/dotnet/samples:aspnetapp

# ejecutar imagen
docker container run <REPOSITORY>:<TAG>
  # --rm = remove container when it exits
  # --detach = run container in background
  # --publish = bind ports HOST:CONTAINER
  # --volume = bind folder HOST:CONTAINER
  # --network NETWORK --network-alias CONTAINER-ALIAS = connect to network
  # --env = set environment variables
  docker container run --rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker container run --rm --detach --publish 8000:80 mcr.microsoft.com/dotnet/samples:aspnetapp

# eliminar imagen
docker image rm <REPOSITORY>:<TAG> | <ID>
  docker image rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker image rm mcr.microsoft.com/dotnet/samples:aspnetapp

```

### Contenedores

```powershell
# listar contenedores
docker container ls --all

# crear contenedor
docker container create <REPOSITORY>:<TAG>
  docker container create mcr.microsoft.com/dotnet/samples:dotnetapp

# iniciar contenedor
docker container start <ID>
  docker container start 123

# detener contenedor
docker container stop <ID>
  docker container stop 123

# elimina contenedor
docker container rm <ID>
  # --force = force the removal of a running container
  docker container rm 123

# elimina contenedores detenidos
docker container prune

# ver logs de contenedor
docker container logs <ID>
  # --follow = continue follow the new output from the container
  docker container logs 123
```

### Build

```powershell
# construir imagen
docker build --tag <REPOSITORY>:<TAG> .
  docker build --tag lusalas16/welcome-to-docker:latest .

# publicar imagen
docker push <REPOSITORY>:<TAG>
  docker push lusalas16/welcome-to-docker:latest
```

### Volumes

```powershell
# listar volúmenes
docker volume ls

# inspeccionar volumen
docker volume inspect <VOLUME NAME>
  docker volume inspect test-volume

# crear volumen
docker volume create <VOLUME NAME>
  docker volume create test-volume
```

### Network

```powershell
# listar redes
docker network ls

# inspeccionar red
docker network inspect <NETWORK NAME>|<NETWORK ID>
  docker network inspect test-network

# crear red
docker network create <NETWORK NAME>|<NETWORK ID>
  docker network create test-network

# conectar red
docker network connect <NETWORK NAME>|<NETWORK ID> <CONTAINER NAME>|<CONTAINER ID>
  docker network connect test-network phpmyadmin
  docker network connect test-network some-mariadb
```

### Exec

```powershell
# ejecutar comando en contenedor
docker exec -it <ID> <COMMAND> <PARAMETERS>
```

### Compose

```powershell
# iniciar docker-compose
  # --detach = run containers in the background
docker-compose --file "example-databases-2.yml" up --detach
# detener docker-compose
docker-compose down
```
