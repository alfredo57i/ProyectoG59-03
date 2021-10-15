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
        private readonly IRepositorioEstadoProducto _repEstadoProducto;
        private readonly IRepositorioEstadoPedido _repEstadoPedido;
        private readonly IRepositorioEstadoFactura _repEstadoFactura;
        public IEnumerable<EstadoProducto> estadosProducto;
        public IEnumerable<EstadoPedido> estadosPedido;
        public IEnumerable<EstadoFactura> estadosFactura;
        
        [BindProperty]
        public EstadoProducto EstadoProducto { get; set; }
        [BindProperty]
        public EstadoPedido EstadoPedido { get; set; }
        [BindProperty]
        public EstadoFactura EstadoFactura{ get; set; }

        public ConfigModel()
        {
            this._repEstadoProducto = new RepositorioEstadoProducto(new ElGordo.App.Persistencia.AppContext());
            this._repEstadoPedido = new RepositorioEstadoPedido(new ElGordo.App.Persistencia.AppContext());
            this._repEstadoFactura = new RepositorioEstadoFactura(new ElGordo.App.Persistencia.AppContext());
            this.estadosProducto = _repEstadoProducto.GetAllEstadosProducto();
            this.estadosPedido = _repEstadoPedido.GetAllEstadosPedido();
            this.estadosFactura = _repEstadoFactura.GetAllEstadosFactura();
        }
        public void OnGet()
        {
            //Se inician los objetos en Blanco
            EstadoProducto = new EstadoProducto{};
            EstadoPedido = new EstadoPedido{};
            EstadoFactura = new EstadoFactura{};
        }

        public IActionResult OnPostNuevo()
        {
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>"+Request.Form["estado"]+"</strong> fue agregado a la lista de Estados.</span>");
            return Page();
        }
        public IActionResult OnPostEditar()
        {
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span><strong>"+Request.Form["estado"]+"</strong> se actualizó correctamente.</span>");
            return Page();
        }
        public IActionResult OnPostEliminar()
        {
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span><strong>"+Request.Form["estadoSelect"]+"</strong> se eliminó de la lista.</span>");
            return Page();
        }
    }
}
