using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebInvManagement.Pages
{
    public class AddPhysicalProductModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Barcode is required")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Barcode must be a 9-digit number")]
        public long Barcode { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Your logic to add the physical product to the inventory goes here
            // Example:
            // inventory.Add(new PhysicalProduct(Name, Description, Price, Quantity, Weight, Barcode));

            // Redirect to the view products page after adding the product
            return RedirectToPage("/ViewProducts");
        }
    }
}
