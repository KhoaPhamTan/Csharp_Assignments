using Asigment1.Data;
using Asigment1.DTOs;
using Asigment1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asigment1.EndPoints
{
    public static class CategoryEndPoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/categories", async (CategoryContext db) =>
            {
                var categoryDtos = await db.Categories
                    .Select(c => new CategoryDto(c.Id, c.Name, c.Price))
                    .ToListAsync();
                return Results.Ok(categoryDtos);
            });

            app.MapGet("/categories/{id}", async (int id, CategoryContext db) =>
            {
                var category = await db.Categories.FindAsync(id);
                if (category == null) return Results.NotFound({});

                var categoryDto = new CategoryDto(category.Id, category.Name, category.Price);
                return Results.Ok(categoryDto);
            });

            app.MapPost("/categories", async (CategoryDto categoryDto, CategoryContext db) =>
            {
                var newCategory = new CategoryEntity
                {
                    Name = categoryDto.Name,
                    Price = categoryDto.Price
                };
                db.Categories.Add(newCategory);
                await db.SaveChangesAsync();
                return Results.Created($"/categories/{newCategory.Id}", newCategory);
            });

            app.MapPut("/categories/{id}", async (int id, CategoryDto categoryDto, CategoryContext db) =>
            {
                var category = await db.Categories.FindAsync(id);
                if (category == null) return Results.NotFound();

                category.Name = categoryDto.Name;
                category.Price = categoryDto.Price;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/categories/{id}", async (int id, CategoryContext db) =>
            {
                var category = await db.Categories.FindAsync(id);
                if (category == null) return Results.NotFound();

                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
