using Asigment1.Data;
using Asigment1.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("PhoneStore");
builder.Services.AddSqlite<CategoryContext>(connString);
builder.Services.AddRazorPages(); 

var app = builder.Build();

// Apply migrations asynchronously
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CategoryContext>();
    await dbContext.MigrateDbAsync(); 
}

// Map endpoints
app.MapCategoryEndpoints();

// Map Razor Pages
app.MapRazorPages(); 

app.Run();
