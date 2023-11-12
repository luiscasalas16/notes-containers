# example-databases-1

```powershell

docker volume create postgres-volume
docker volume create mariadb-volume
docker volume create cloudbeaver-volume

docker network create databases-network

# postgres
# https://hub.docker.com/_/postgres

docker pull postgres:16.0-bookworm

docker container run `
  --detach `
  --name some-postgres `
  --publish 5432:5432 `
  --env POSTGRES_USER=example-user `
  --env POSTGRES_PASSWORD=prueba123* `
  --volume postgres-volume:/var/lib/postgresql/data `
  --network databases-network `
  postgres:16.0-bookworm

# mariadb
# https://hub.docker.com/_/mariadb

docker pull mariadb:11.1.2-jammy

docker container run `
  --detach `
  --name some-mariadb `
  --publish 3306:3306 `
  --env MARIADB_USER=example-user `
  --env MARIADB_PASSWORD=prueba123* `
  --env MARIADB_ROOT_PASSWORD=prueba123* `
  --env MARIADB_DATABASE=mariadb `
  --volume mariadb-volume:/var/lib/mysql `
  --network databases-network `
  mariadb:11.1.2-jammy

#dbeaver/cloudbeaver
#https://hub.docker.com/r/dbeaver/cloudbeaver

docker pull dbeaver/cloudbeaver:latest

docker container run `
  --detach `
  --name cloudbeaver `
  --volume cloudbeaver-volume:/opt/cloudbeaver/workspace `
  --publish 8080:8978 `
  --network databases-network `
  dbeaver/cloudbeaver:latest

```
