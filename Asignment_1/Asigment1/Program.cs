using Asigment1.Data;
using Asigment1.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<CategoryContext>(connString);

var app = builder.Build();

// Apply migrations asynchronously
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CategoryContext>();
    await dbContext.MigrateDbAsync(); // Call the async migration method
}

// Map endpoints
app.MapCategoryEndpoints();

app.Run();
