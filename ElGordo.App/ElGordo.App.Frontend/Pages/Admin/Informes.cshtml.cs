using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGrodo.App.Frontend.Pages
{
    [Authorize]
    public class InformesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
