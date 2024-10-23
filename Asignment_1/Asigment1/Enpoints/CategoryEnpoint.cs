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
                if (!categoryDtos.Any())
                {
                    return Results.NotFound(new { Message = "No records found." });
                }

                return Results.Ok(categoryDtos);
            });

            app.MapGet("/categories/{id}", async (int id, CategoryContext db) =>
            {
                var category = await db.Categories.FindAsync(id);
                if (category == null) return Results.NotFound(new { Message = "No records found." });

                var categoryDto = new CategoryDto(category.Id, category.Name, category.Price);
                return Results.Ok(categoryDto);
            });

            app.MapPost("/categories", async (CategoryDto categoryDto, CategoryContext db) =>
            {
                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    return Results.BadRequest(new { Message = "Name is a required field." });
                }

                if (categoryDto.Price <= 0)
                {
                    return Results.BadRequest(new { Message = "Price must be a positive number." });
                }

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
                if (category == null) return Results.NotFound(new { Message = "Category not found." });

                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    return Results.BadRequest(new { Message = "Name is a required field." });
                }

                if (categoryDto.Price <= 0)
                {
                    return Results.BadRequest(new { Message = "Price must be a positive number." });
                }

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
