using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGrodo.App.Frontend.Pages
{
    [Authorize]
    public class InformesModel : PageModel
    {
        private static readonly IRepositorioPedido _repoPedidos = new RepositorioPedido(new ElGordo.App.Persistencia.AppContext());
        public IRepositorioProductos _repoProroductos = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        public IRepositorioFactura _repoFactura = new RepositorioFactura(new ElGordo.App.Persistencia.AppContext());
        public IEnumerable<Pedido> Pedidos { get; set; }
        public void OnGet()
        {
            Pedidos = _repoPedidos.GetAll();
        }
        public IActionResult OnPost()
        {
            // ViewData["fechamin"] = Request.Form["fechamin"];
            // ViewData["fechamax"] = Request.Form["fechamax"];
            // Console.WriteLine(Request.Form["fechamin"]+" "+Request.Form["fechamax"]);
            // Pedidos = _repoPedidos.GetAll();
            return Page();
        }
    }
}