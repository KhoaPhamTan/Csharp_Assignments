using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace CategoryRazorMVC.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("CategoryAPI");
            var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
            Categories = categories ?? new List<CategoryDto>();
        }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
