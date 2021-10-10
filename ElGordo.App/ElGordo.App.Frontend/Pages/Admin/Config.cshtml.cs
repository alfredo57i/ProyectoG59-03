using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ElGrodo.App.Frontend.Pages
{
    [Authorize]
    public class ConfigModel : PageModel
    {
        private static readonly IRepositorioEstadoProducto _repEstadoProducto = new RepositorioEstadoProducto(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioEstadoPedido _repEstadoPedido = new RepositorioEstadoPedido(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioEstadoFactura _repEstadoFactura = new RepositorioEstadoFactura(new ElGordo.App.Persistencia.AppContext());
        public IEnumerable<EstadoProducto> estadosProducto = _repEstadoProducto.GetAllEstadosProducto();
        public IEnumerable<EstadoPedido> estadosPedido = _repEstadoPedido.GetAllEstadosPedido();
        public IEnumerable<EstadoFactura> estadosFactura = _repEstadoFactura.GetAllEstadosFactura();
        
        [BindProperty]
        public EstadoProducto EstadoProducto { get; set; }
        public void OnGet()
        {
            //Se inician los objetos en Blanco
            EstadoProducto = new EstadoProducto{};
        }

        public IActionResult OnPostNuevoEstadoProducto()
        {            
            //Console.WriteLine(JsonSerializer.Serialize(EstadoProducto));
            if (!ModelState.IsValid) {
                return Page(); 
            }
            //_repEstadoProducto.AddEstadoProducto(EstadoProducto);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span>"+EstadoProducto.Nombre+" fue agregado a la lista de <strong>Estados Producto</strong>.</span>");
            return Page();
        }
        public void OnPostEditarEstadoProducto()
        {
            Console.WriteLine("Editar");
        }
        public void OnPostEliminarEstadoProducto()
        {
            Console.WriteLine("Eliminar");
        }
    }
}
