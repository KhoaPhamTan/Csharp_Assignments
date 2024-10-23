using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Asigment1.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            // Hardcoded data
            Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Iphone 16", Price = 222559.99M },
                new Category { Id = 2, Name = "Iphone 15", Price = 205229.99M },
                new Category { Id = 3, Name = "Samsung S24", Price = 202250.99M },
                new Category { Id = 4, Name = "Nokia 8025", Price = 5022.99M }
            };
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}



// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using Asigment1.Data;
// using Asigment1.Entities;

// namespace Asigment1.Pages.Categories
// {
//     public class IndexModel : PageModel
//     {
//         private readonly CategoryContext _context;

//         public IndexModel(CategoryContext context)
//         {
//             _context = context;
//         }

//         public IList<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();

//         public async Task OnGetAsync()
//         {
//             Categories = await _context.Categories.ToListAsync();
//         }
//     }
// }
