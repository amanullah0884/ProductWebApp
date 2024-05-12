using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWebApp.Data;
using ProductWebApp.Model;

namespace ProductWebApp.Pages.Production
{
    public class CreateModel : PageModel
    {
        private readonly AppDbProduct _db;

        [BindProperty]
        public Model.Product Iproduct { get; set; }
        public CreateModel(AppDbProduct db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (Iproduct.Name==Iproduct.Quentity.ToString())             {
                ModelState.AddModelError(String.Empty, "DisplayOrder Name cann't be match :");
            }
            if(ModelState.IsValid)
            {
                await _db.Products.AddAsync(Iproduct);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
