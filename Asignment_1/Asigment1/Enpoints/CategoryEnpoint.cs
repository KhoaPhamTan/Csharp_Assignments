using Asigment1.DTOs;
using Asigment1.Entities;

namespace Asigment1.EndPoints
{
    public static class CategoryEndPoints
    {
        private static List<CategoryEntity> categories = new List<CategoryEntity>
        {
            new CategoryEntity { Id = 1, Name = "Iphone", Price = 1999.99m },
            new CategoryEntity { Id = 2, Name = "Samsung", Price = 1679.99m },
            new CategoryEntity { Id = 3, Name = "Nokia", Price = 139.99m }
        };

        public static void MapCategoryEndpoints(this WebApplication app)
        {
          //test GIt .. ... .. test ... update 3
            app.MapGet("/categories", () => 
            {
                var categoryDtos = categories.Select(c => new CategoryDto(c.Id, c.Name, c.Price));
                return Results.Ok(categoryDtos);
            });

        
            app.MapGet("/categories/{id}", (int id) =>
            {
                var category = categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                {
                    return Results.NotFound();
                }

                var categoryDto = new CategoryDto(category.Id, category.Name, category.Price);
                return Results.Ok(categoryDto);
            });

            app.MapPost("/categories", (CategoryDto categoryDto) =>
            {
                var newCategory = new CategoryEntity
                {
                    Id = categories.Count + 1,
                    Name = categoryDto.Name,
                    Price = categoryDto.Price
                };
                categories.Add(newCategory);
                return Results.Created($"/categories/{newCategory.Id}", newCategory);
            });

        
            app.MapPut("/categories/{id}", (int id, CategoryDto categoryDto) =>
            {
                var category = categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                {
                    return Results.NotFound();
                }

                category.Name = categoryDto.Name;
                category.Price = categoryDto.Price;

                return Results.NoContent();
            });

      
            app.MapDelete("/categories/{id}", (int id) =>
            {
                var category = categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                {
                    return Results.NotFound();
                }

                categories.Remove(category);
                return Results.NoContent();
            });
        }
    }
}
