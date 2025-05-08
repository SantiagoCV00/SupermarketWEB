using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Products Products { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var products = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                Products = products;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var products = await _context.Products.FindAsync(id);

            if (products != null)
            {
                Products = products;
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
