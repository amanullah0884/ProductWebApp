using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductWebApp.Data;
using ProductWebApp.Model;
using System.Linq;

namespace ProductWebApp.Pages.Production
{
    public class IndexModel : PageModel
    {
        public readonly AppDbProduct _db;
            public IEnumerable<Model.Product> productinfo { get; set; }
        public IndexModel(AppDbProduct db)
        {
            _db = db;
        }
        public async Task OnGet()
        {
            productinfo =await _db.Products.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Pro = await _db.Products.FindAsync(id);
            if (Pro == null)
            {
                return NotFound();
            }
            _db.Products.Remove(Pro);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
