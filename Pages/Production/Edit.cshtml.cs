using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductWebApp.Data;
namespace ProductWebApp.Pages.Production
{
    public class EditModel : PageModel
    {
        private AppDbProduct _db;
       
        public EditModel(AppDbProduct db)
        {
            _db = db;   
        }
        [BindProperty]
        public Model.Product ProductEd { get; set; }
        public async Task OnGet(int id)
        {
            ProductEd = await _db.Products.FindAsync(id);
        }
        public async Task<IActionResult>OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProEd = await _db.Products.FindAsync(ProductEd.Id);
                ProEd.Name = ProductEd.Name;
                ProEd.Price = ProductEd.Price;
                ProEd.Quentity=ProductEd.Quentity;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
           
        }
    }
}
