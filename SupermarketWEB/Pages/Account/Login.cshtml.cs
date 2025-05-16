using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;
using SupermarketWEB.Data; 
using Microsoft.EntityFrameworkCore; 

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context; 

        public LoginModel(SupermarketContext context) 
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

  
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Email);

            if (dbUser == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

 
            if (dbUser.Password != User.Password) 
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dbUser.Email), 
                new Claim(ClaimTypes.Email, dbUser.Email),
            };

  
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            return RedirectToPage("/Index");
        }
    }
}