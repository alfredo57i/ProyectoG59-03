using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ElGordo.App.Frontend.Pages
{
    public class AcerdaDeModel : PageModel
    {
        private readonly ILogger<AcerdaDeModel> _logger;

        public AcerdaDeModel(ILogger<AcerdaDeModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}