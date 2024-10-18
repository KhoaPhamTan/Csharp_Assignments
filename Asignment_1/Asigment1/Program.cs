using Asigment1.EndPoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapCategoryEndpoints();

app.Run();
