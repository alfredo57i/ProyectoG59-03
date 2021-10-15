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
        }

        //Al hacer clic en el boton Pagar captura los datos del pedido y los guarda en una variable de sesión
        public IActionResult OnPostHacerPedido()
        {
            if (!ModelState.IsValid) { return CargaDatos();}
            //Variable de sesión
            HttpContext.Session.SetString("pedido", JsonSerializer.Serialize(Pedido));
            return RedirectToPage("/Pedido/Pago");
        }

        public IActionResult CargaDatos()
        {
            //Comprueba que existan datos en la variable de sesión "carrito"
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