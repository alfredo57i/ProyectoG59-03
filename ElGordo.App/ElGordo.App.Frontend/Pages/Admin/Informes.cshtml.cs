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
        private readonly IRepositorioPedido _repoPedidos;
        public IRepositorioProductos _repoProroductos;
        public IRepositorioFactura _repoFactura;
        public IEnumerable<Pedido> Pedidos { get; set; }

        public InformesModel()
        {
            this._repoPedidos = new RepositorioPedido(new ElGordo.App.Persistencia.AppContext());
            this._repoProroductos = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
            this._repoFactura = new RepositorioFactura(new ElGordo.App.Persistencia.AppContext());
        }
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