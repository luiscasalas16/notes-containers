# notes-containers / docker

- [Documentación](#documentación)
- [Instalación](#instalación)
- [Comandos](#comandos)

## Fundamentos

- [Docker, Definición](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/container-docker-introduction/docker-defined)
- [Docker, Terminología](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/container-docker-introduction/docker-terminology)

## Documentación

- [Get-Started Docker](https://docs.docker.com/get-started/)
- [Get-Started Docker Desktop](https://docs.docker.com/get-started/hands-on-overview)
- [Docker command line reference](https://docs.docker.com/engine/reference/commandline/cli/)
- [Docker dockerfile reference](https://docs.docker.com/engine/reference/builder/)
- [Docker dockercompose reference](https://docs.docker.com/compose/compose-file/)
- [Docker cheat-sheet](https://devtalles.com/files/docker-cheat-sheet.pdf)
- [DOCKER De NOVATO a PRO!, Pelado Nerd, 1 hora](https://www.youtube.com/watch?v=CV_Uf3Dq-EU)

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

## Cursos

- [Aprende Docker ahora! - HolaMundo](https://www.youtube.com/watch?v=4Dko5W96WHg)
- [Docker - Guía práctica de uso para desarrolladores - Fernando Herrera](https://www.udemy.com/course/docker-guia-practica/)

## Comandos

### Imágenes

```powershell
# listar imágenes
docker image ls

# obtener imagen
docker pull <IMAGE>:<TAG>
  docker pull mcr.microsoft.com/dotnet/samples:dotnetapp
  docker pull mcr.microsoft.com/dotnet/samples:aspnetapp

# ejecutar imagen
docker container run <IMAGE>:<TAG>
  # --rm = remove container when it exits
  # --detach = run container in background
  # --publish = bind ports HOST:CONTAINER
  # --volume = bind folder HOST:CONTAINER
  # --network NETWORK --network-alias CONTAINER-ALIAS = connect to network
  # --env = set environment variables
  docker container run --rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker container run --rm --detach --publish 8000:80 mcr.microsoft.com/dotnet/samples:aspnetapp

# eliminar imagen
docker image rm <IMAGE>:<TAG> | <ID>
  docker image rm mcr.microsoft.com/dotnet/samples:dotnetapp
  docker image rm mcr.microsoft.com/dotnet/samples:aspnetapp

```

### Contenedores

```powershell
# listar contenedores
docker container ls --all

# crear contenedor
docker container create <IMAGE>:<TAG>
  docker container create mcr.microsoft.com/dotnet/samples:dotnetapp

# iniciar contenedor
docker container start <ID>
  docker container start 123

# crear e iniciar contenedor
docker container run <IMAGE>:<TAG>
  # --d = ...
  docker container run mcr.microsoft.com/dotnet/samples:dotnetapp

# conectarse a contenedor
docker exec -it <ID> /bin/sh

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
docker build --tag <IMAGE>:<TAG> .
  docker build --tag welcome-to-docker:latest .

# publicar imagen
docker login

docker push <IMAGE>:<TAG>
  docker push welcome-to-docker:latest

docker logout

# tagear imagen
docker image tag <SOURCE_IMAGE>:<TAG> <TARGET_IMAGE>:<TAG>
  docker image tag welcome-to-docker:latest welcome-to-docker:previous
```

### BuildX

```powershell

# listar builder
docker buildx ls

# crear builder
docker buildx create --name mybuilder --driver docker-container --bootstrap

# usar builder
docker buildx use mybuilder

# construir y publicar imagen
docker buildx build --platform linux/amd64,linux/arm64 --tag lusalas16/hello --push .\docker\.

# usar builder
docker buildx use default

# eliminar builder
docker buildx rm mybuilder
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
  docker volume create test-volume --opt o=bind --opt type=none --opt device=C:\test-volume
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
docker-compose --file ".\docker\example-databases-2.yml" up --detach
# detener docker-compose
docker-compose --file ".\docker\example-databases-2.yml" down
```
