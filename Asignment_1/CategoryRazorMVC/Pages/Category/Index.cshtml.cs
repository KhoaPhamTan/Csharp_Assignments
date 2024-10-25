using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CategoryRazorMVC.Pages.Category
{
    public class IndexModel : PageModel
    {
        public List<CategoryDto> Categories { get; set; } = new();

        public void OnGet()
        {
            Categories = new List<CategoryDto>
            {
                new CategoryDto(1, "SamSung", 1200.50m),
                new CategoryDto(2, "Nokia", 250.75m),
                new CategoryDto(3, "Iphone", 99.99m)
            };
        }
    }

    public record CategoryDto(int Id, string Name, decimal Price);
}
