using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGrodo.App.Frontend.Pages
{
    [Authorize]
    public class IndexAdminModel : PageModel
    {
        private static readonly IRepositorioPedido _repoPedidos = new RepositorioPedido(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioEstadoPedido _repoEstadoPedidos = new RepositorioEstadoPedido(new ElGordo.App.Persistencia.AppContext());
        public IRepositorioFactura _repoFactura = new RepositorioFactura(new ElGordo.App.Persistencia.AppContext());
        public IRepositorioProductos _repoProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<EstadoPedido> EstadoPedidos { get; set; }
        public string marcadores { get; set; }

        public void OnGet()
        {
            CargaPagina();
        }

        public string RecorrerPedidos()
        {
            var datos = "";
            foreach (var pedido in Pedidos)
            {
                datos += "{coords: { lat: " + pedido.LatitudEntrega + ", lng: " + pedido.LongitudEntrega + " }, img: iconBase, con: '<h5>" + pedido.Cliente + "</h5>";
                foreach (var item in _repoFactura.GetFactura(pedido.Factura).Detalles)
                {
                    var producto = _repoProducto.GetProducto(item.Producto);
                    datos += "<p>"+producto.Nombre + " x " + item.Cantidad+"</p>";
                }
                datos += "'},";
            }
            return datos;
        }

        public void OnPost()
        {
        }

        public void CargaPagina()
        {
            var listaEstado = HttpContext.Session.GetInt32("lista") ?? 0;
            ViewData["listar"] = listaEstado;
            if (listaEstado == 0)
            {
                Pedidos = _repoPedidos.GetAll();
            }
            else
            {
                Pedidos = _repoPedidos.GetPedidoPorEstado(listaEstado);
            }
            EstadoPedidos = _repoEstadoPedidos.GetAllEstadosPedido();
            marcadores = RecorrerPedidos();
            ViewData["marcadores"] = marcadores;
        }

        public IActionResult OnPostCambiaLista()
        {
            HttpContext.Session.SetInt32("lista", int.Parse(Request.Form["listaEstado"]));
            CargaPagina();
            return RedirectToPage("/Admin/Index");
        }

        public IActionResult OnPostCambiaEstado()
        {
            var pedido = _repoPedidos.GetPedido(int.Parse(Request.Form["idpedido"]));
            _repoPedidos.UpdateEstadoPedido(pedido.Id, pedido.Estado + 1);
            CargaPagina();
            return RedirectToPage("/Admin/Index");
        }

        public IActionResult OnPostBusca()
        {
            return RedirectToPage("/Admin/Index");
        }
    }
}
