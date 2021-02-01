#!/bin/bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Atec@Password!' -p 1401:1433 -d --name=db_book_sql microsoft/mssql-server-linux:2017-latest
# docker exec -it db_book_sql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'Atec@Password!'
