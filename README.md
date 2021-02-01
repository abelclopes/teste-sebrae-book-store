
## configurar database docker
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Atec@Password!' -p 1401:1433 -d --name=db_book_sql microsoft/mssql-server-linux:2017-latest
## testando conecção com database
docker exec -it db_book_sql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'Atec@Password!'


## Build e restore
```
cd /src
dotnet restore
dotnet build

```

## RUN APP
cd src/WebApplication

## migrations

```
cd /src/WebApplication/ 

dotnet-ef migrations add InitialCreate --output-dir Data/Migrations
```
## atualizar database

```
dotnet ef database update
```

## Rodar sistema

```
cd src/WebApplication
dotnet run
https://localhost:5001

```
