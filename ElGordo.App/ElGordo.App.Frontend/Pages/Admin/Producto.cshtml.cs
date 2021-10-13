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
using Microsoft.AspNetCore.Hosting;

namespace ElGrodo.Frontend.Pages
{
    [Authorize]
    public class ProductoModel : PageModel
    {
        private readonly IWebHostEnvironment _enviroment;
        private static readonly IRepositorioProductos _repProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioEstadoProducto _repEstadoProducto = new RepositorioEstadoProducto(new ElGordo.App.Persistencia.AppContext());
        [BindProperty]
        public Producto Producto { get; set; }
        [BindProperty]
        public IFormFile Imagen { get; set; }
        public IEnumerable<EstadoProducto> estadosProducto = _repEstadoProducto.GetAllEstadosProducto();
        public ProductoModel(IWebHostEnvironment environment)
        {
            _enviroment = environment;
        }
        public IActionResult OnGet(int? productoId)
        {
            //Si el productoId que llega por GET tiene un valor
            if (productoId.HasValue)
            {
                //Busca el producto en la base de datos
                Producto = _repProducto.GetProducto(productoId.Value);
            }
            else
            {
                //Crea un nuevo producto y agrega valores por defecto
                Producto = new Producto { Estado = 1, Imagen = "default.png" };
            }

            //Si envian un Id de producto que no está en la base de datos
            if (Producto == null)
            {
                //Devuelve la pagina de error
                return Redirect("/Errors/404");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPost(int estado)//Estado es el nombre del Select estados.
        {
            Producto.Estado = estado;
            //Console.WriteLine(JsonSerializer.Serialize(Producto));
            if (!ModelState.IsValid) { return Page(); }
            
            if (Imagen != null)
            {//Si se ha seleccionado una imagen la sube a la carpeta "wwwroot\img"
            // Producto.Imagen = Imagen.FileName;
                var imgUpload = System.IO.Path.Combine(_enviroment.ContentRootPath, "wwwroot\\img", Imagen.FileName);
                await Imagen.CopyToAsync(new System.IO.FileStream(imgUpload, System.IO.FileMode.Create));
            }
            if (Producto.Id > 0)
            {
                //Si el Id del producto es mayor que cero actualizar el Producto enviado
                Producto = _repProducto.UpdateProducto(Producto);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span>" + Producto.Nombre + " fue modificado correctamente</span>");
            }
            else
            {
                //Si el Id del Prodcuto es CERO crea un nuevo producto
                _repProducto.AddProducto(Producto);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>" + Producto.Nombre + "</strong> se agregó a la lista de productos</span>");
            }

            return Page();
        }
    }
}