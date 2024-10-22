using Asigment1.Data;
using Asigment1.EndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm DbContext vào DI container
builder.Services.AddDbContext<CategoryContext>(options =>
    options.UseSqlite("Data Source=categories.db"));

var app = builder.Build();

// Đăng ký các endpoint
app.MapCategoryEndpoints();

// Khởi tạo cơ sở dữ liệu nếu chưa tồn tại
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CategoryContext>();
    db.Database.EnsureCreated(); // Tạo cơ sở dữ liệu nếu chưa tồn tại
}

// Chạy ứng dụng
app.Run();
