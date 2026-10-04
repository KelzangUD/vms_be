
# Documentation
*Currently I don't have laptop, so the code is pushed from another git to my GitHub Repo*

The project is developed in Asp.Net Core with Entity Framework Core. It Uses SQL Express for database.

### Steps For Project Setup and Running Project:
#### 1. Clone the project using Git
#### 2. Install necessary packages to run the project
> Install-Package Microsoft.EntityFrameworkCore.SqlServer
> Install-Package Microsoft.EntityFrameworkCore.Design
> Install-Package Microsoft.EntityFrameworkCore.Tools
> Install-Package Microsoft.OpenApi -Version 2.7.5
> Install-Package Swashbuckle.AspNetCore
> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 10.0.10

#### 3. Paste following code in appsettings.Development.json file
``
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=vms_db;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "MyLocalDevOnlySecretKeyThatIsAtLeast32BytesLong!"
  },
  "AllowedOrigins": [
    "http://localhost:5173"
  ]
}
``
#### 4. Run migration
> Add-Migration InitVehicleManagementSystem
*After running migration, if you can’t find database and the data seeded in table, run following command:
> Update-Database

### For Unit Testing and Integration Testing
#### Unit Testing
Install necessary package for unit test:
> Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 10.0.12 -ProjectName UnitTests
> Install-Package NSubstitute -ProjectName UnitTests

If there is issue while in Unit Test, clean everything and rebuild
> Remove-Item -Recurse -Force UnitTests\bin, UnitTests\obj
> dotnet restore UnitTests
> dotnet build UnitTests

Command to run unit test
> dotnet test UnitTests

#### Integration Testing
Install neccessary package for integration testing
> Install-Package Microsoft.AspNetCore.Mvc.Testing -Version 10.0.12 -ProjectName IntegrationTests
> Install-Package Microsoft.AspNetCore.Mvc.Testing -Version 10.0.12 -ProjectName IntegrationTests
> Install-Package Microsoft.AspNetCore.Mvc.Testing -ProjectName IntegrationTests

Build integration testing
> dotnet build IntegrationTests
Run Integration Testing
> dotnet test IntegrationTests

### Design Notes
The project architecture is very simple. It Contains Controllers, Models and Services as main three directory.
> Controllers: Contains all the endpoints
> Models: Data Representation
> Services: All application logic

### Database Design
There are 4 tables in database as you will see in the Models directory.
The ApplicationDbContext file also contains all predefined data while will be generated after migration.





