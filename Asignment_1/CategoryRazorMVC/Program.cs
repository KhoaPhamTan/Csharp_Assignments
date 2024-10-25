var builder = WebApplication.CreateBuilder(args);

// Thêm HttpClient
builder.Services.AddHttpClient("CategoryAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5113/"); // Địa chỉ API
});

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
