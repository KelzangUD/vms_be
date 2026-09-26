using Microsoft.EntityFrameworkCore;
using vms_be;

var builder = WebApplication.CreateBuilder(args);

// read the connection string dynamically (pulls from appsettings.Development.json locally)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// register applicationDbContext with the DI container
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{ 
    //enable development tools like Swagger/OpenAPI here
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();