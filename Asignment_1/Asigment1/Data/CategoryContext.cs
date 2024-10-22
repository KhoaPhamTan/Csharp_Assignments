using Microsoft.EntityFrameworkCore;
using Asigment1.Entities;

namespace Asigment1.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasKey(c => c.Id);
        }
    }
}
