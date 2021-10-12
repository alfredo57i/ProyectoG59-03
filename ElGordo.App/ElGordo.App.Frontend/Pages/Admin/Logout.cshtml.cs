using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGrodo.App.Frontend.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("CookieAdmin").ConfigureAwait(false);
            return RedirectToPage("/Admin/Index");
        }

        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync("CookieAdmin").ConfigureAwait(false);
            return RedirectToPage("/Admin/Index");
        }
    }
}