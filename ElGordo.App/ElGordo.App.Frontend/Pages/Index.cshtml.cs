using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGordo.App.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ElGordo.App.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly IRepositorioProductos _repProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        // private readonly IRepositorioProductos repProductos;
        public IEnumerable<Producto> Productos { get; set; }
        public string Listado { get; set; }

        public IndexModel()
        {
            this.Productos = _repProducto.GetDisponibles(1);//El "1" Para obtener los productos Disponibles
        }

        public void OnGet()
        {
            ViewData["JsonCarrito"] = HttpContext.Session.GetString("carrito")??"[]";
            Productos = _repProducto.GetDisponibles(1);//El "1" Para obtener los productos Disponibles            
        }

        public void OnPost(string carrito)
        {
            Console.WriteLine("llega");
            var lista = JsonConvert.DeserializeObject<List<Carrito>>(carrito);
            foreach (var item in lista)
            {
                Console.WriteLine(item.Item + " X " + item.Cantidad);
            }
            HttpContext.Session.SetString("carrito", carrito);
            ViewData["JsonCarrito"] = carrito;
        }

        public IActionResult OnPostGuarda(string carrito)
        {
            HttpContext.Session.SetString("carrito", carrito);
            return new JsonResult("todo ok desde servidor");
        }
    }
}
