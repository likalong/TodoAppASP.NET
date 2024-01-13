# TodoAppASP.NET
Practicing CRUD API Service with dotnet 6.0

#### NuGet Package need:
- Newtonsoft
- SqlClient
- AspNetCore
- Dapper

#### Tools Requirement
- Docker Setup
- Database management system >> Asure Data Studio
  download from 39
https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio?tabs=win-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall

#### Setup Docker with Asure
- run this command : Tools
```
docker pull mcr.microsoft.com/azure-sql-edge
```

- Setup MSSQl database local
```
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Password123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

#### Connection String in appseting.json
- the connection string
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodosAppDB;User Id=sa;Password=Password123;TrustServerCertificate=True;"
},
```

#### Configuration to connect DB in Controller Class
```
private readonly IConfiguration _configuration;
```
Then in its constructure
```
public TodosController(ITodosService todoService, IConfiguration _config)
    {
        _configuration = _config;
        _todoService = todoService;
    }
```

Everytime need to read or write data to database need to call for connection as below;
```
 using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
```

**Note: Create Database table in local before connection.
