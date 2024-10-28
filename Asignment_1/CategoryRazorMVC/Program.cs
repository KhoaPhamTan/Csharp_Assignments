// var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddHttpClient("CategoryAPI", client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5113/"); // Địa chỉ API
// });

// builder.Services.AddRazorPages();

// var app = builder.Build();

// app.UseStaticFiles();
// app.UseRouting();
// app.UseAuthorization();
// app.MapRazorPages();

// app.Run();



var builder = WebApplication.CreateBuilder(args);

var apiSettings = builder.Configuration.GetSection("ApiSettings");
var categoryApiUrl = apiSettings.GetValue<string>("CategoryApiUrl");


if (string.IsNullOrEmpty(categoryApiUrl))
{
    throw new Exception("CategoryApiUrl is not set in appsettings.json");
}

builder.Services.AddHttpClient("CategoryAPI", client =>
{
    client.BaseAddress = new Uri(categoryApiUrl);
});

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

