using Microsoft.EntityFrameworkCore;

namespace Asigment1.Data
{
    public static class DbContextExtensions
    {
        public static async Task MigrateDbAsync(this CategoryContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
