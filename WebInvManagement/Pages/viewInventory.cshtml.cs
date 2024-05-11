using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebInvManagement.Pages
{
    public class ViewInventoryModel : PageModel
    {
        private readonly MongoDBService _mongoDBService;

        public ViewInventoryModel(WebInvManagement.Pages.MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
            Products = new List<Product>(); // Initialize Products list
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var productCollection = _mongoDBService.GetCollection<Product>("products");
            Products = await productCollection.Find(_ => true).ToListAsync();
        }
    }
}
