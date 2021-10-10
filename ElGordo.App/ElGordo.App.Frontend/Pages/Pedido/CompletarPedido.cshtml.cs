using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ElGrodo.App.Frontend.Pages
{
    public class CompletarPedidoModel : PageModel
    {
        [BindProperty]
        public Pedido Pedido{get;set;}
        public IActionResult OnGet()
        {
            return CargaDatos();
        }
        public IActionResult OnPost()
        {
            return CargaDatos();
            // Console.WriteLine(Request.Form["pedido"]);
            // //det listaDetalles = System.Text.Json.JsonSerializer.Deserialize<det>(Request.Form["pedido"]);
            // //ViewData["JsonPedido"] = HttpContext.Session.GetString("listaProd");
            // ViewData["JsonPedido"]=Request.Form["pedido"];
        }
        public IActionResult OnPostHacerPedido()
        {
            if (!ModelState.IsValid) { return CargaDatos();}
            HttpContext.Session.SetString("pedido", JsonSerializer.Serialize(Pedido));
            return RedirectToPage("/Pedido/Pago");
        }

        public IActionResult CargaDatos()
        {
            if(HttpContext.Session.GetString("carrito") == null||HttpContext.Session.GetString("carrito") == "[]"){
                ViewData["JsonCarrito"] = "[]";
                return RedirectToPage("/Index");
            }else{
                ViewData["JsonCarrito"] = HttpContext.Session.GetString("carrito");
                return Page();
            } 
        }
    }
}
