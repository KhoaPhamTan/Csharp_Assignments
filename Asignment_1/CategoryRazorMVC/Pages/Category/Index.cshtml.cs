// using Microsoft.AspNetCore.Mvc.RazorPages;
// using CategoryLibrary; // Thêm sử dụng Razor Class Library

// namespace CategoryRazorMVC.Pages.Category
// {
//     public class IndexModel : PageModel
//     {
//         private readonly IHttpClientFactory _clientFactory;

//         public IndexModel(IHttpClientFactory clientFactory)
//         {
//             _clientFactory = clientFactory;
//         }

//         public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

//         public async Task OnGetAsync()
//         {
//             var client = _clientFactory.CreateClient("CategoryAPI");
//             var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
//             Categories = categories ?? new List<CategoryDto>();
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc.RazorPages;
using CategoryLibrary; // Thêm sử dụng Razor Class Library
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
            try
            {
                var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
                Categories = categories ?? new List<CategoryDto>();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu có)
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                Categories = new List<CategoryDto>(); // Đảm bảo không có null
            }
        }
    }
}
