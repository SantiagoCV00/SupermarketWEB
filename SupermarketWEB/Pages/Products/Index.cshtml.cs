using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;
        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }
        public IList<Models.Products> Products { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Products = await _context.Products.ToListAsync();
            }
        }
    }
}
