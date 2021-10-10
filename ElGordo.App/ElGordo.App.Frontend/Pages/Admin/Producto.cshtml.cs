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

namespace ElGrodo.Frontend.Pages
{
    [Authorize]
    public class ProductoModel : PageModel
    {
        private static readonly IRepositorioProductos _repProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioEstadoProducto _repEstadoProducto = new RepositorioEstadoProducto(new ElGordo.App.Persistencia.AppContext());
        // private readonly IRepositorioProductos repProductos;
        [BindProperty]
        public Producto Producto { get; set; }
        public IEnumerable<EstadoProducto> estadosProducto = _repEstadoProducto.GetAllEstadosProducto();
        public ProductoModel()
        {
        }
        public IActionResult OnGet(int? productoId)
        {
            if (productoId.HasValue)
            {
                Producto = _repProducto.GetProducto(productoId.Value);
            }
            else
            {
                Producto = new Producto
                {
                    Estado = 1,
                    Imagen = "default.png"
                };
            }

            if (Producto == null)
            {
                return Redirect("/404");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int estado)//Estado es el nombre del Select estados.
        {
            Producto.Estado=estado;
            //Console.WriteLine(JsonSerializer.Serialize(Producto));
            if (!ModelState.IsValid) { return Page(); }
            if (Producto.Id > 0)
            {
                Producto = _repProducto.UpdateProducto(Producto);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span>"+Producto.Nombre+" fue modificado correctamente</span>");
            }
            else
            {
                _repProducto.AddProducto(Producto);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>"+Producto.Nombre+"</strong> se agregó a la lista de productos</span>");
            }

            return Page();
        }
    }
}
