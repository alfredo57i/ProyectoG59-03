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
        public IRepositorioPedido _repoPedidos;
        public IRepositorioEstadoPedido _repoEstadoPedidos;
        public IRepositorioFactura _repoFactura;
        public IRepositorioProductos _repoProducto;
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<EstadoPedido> EstadoPedidos { get; set; }
        public string Marcadores { get; set; }

        public IndexAdminModel()
        {
            this._repoPedidos = new RepositorioPedido(new ElGordo.App.Persistencia.AppContext());
            this._repoEstadoPedidos = new RepositorioEstadoPedido(new ElGordo.App.Persistencia.AppContext());
            this._repoFactura = new RepositorioFactura(new ElGordo.App.Persistencia.AppContext());
            this._repoProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            CargaPagina();
        }       

        //=============================================================================
        //Carga el tipo de pedidos dependiendo de la opción seleccinada.
        public void CargaPagina()
        {
            //Si no se ha seleccionado ningun tipo de pedido se selecciona "Todos" por defecto
            var listaEstado = HttpContext.Session.GetInt32("lista") ?? 0;
            ViewData["listar"] = listaEstado;
            //Si no se ha asignado un tipo de pedidos, se muestran todos los pedidos pendientes para entregar
            //De lo contrario busca los pedidos por estado.
            Pedidos = (listaEstado == 0)?_repoPedidos.GetPendientes():_repoPedidos.GetPedidoPorEstado(listaEstado);
            //Obtiene los estados de pedido.
            EstadoPedidos = _repoEstadoPedidos.GetAllEstadosPedido();
            //Llama a la función RecorrerPedidos que se encarga 
            Marcadores = RecorrerPedidos();
            //Envía los marcadores del mapa a la vista.
            ViewData["marcadores"] = Marcadores;
        }

        //======================================================================================
        //Recorre la lista de pedidos y agrega las coordenadas e información necesaria para mostrar los marcadores en el mapa
        public string RecorrerPedidos()
        {
            var datos = "";
            //Recorre cada pedido
            foreach (var pedido in Pedidos)
            {
                datos += "{coords: { lat: " + pedido.LatitudEntrega + ", lng: " + pedido.LongitudEntrega + " }, img: iconBase, con: '<h5>" + pedido.Cliente + "</h5>";
                //Recorre cada detalle en la Factura
                foreach (var item in _repoFactura.GetFactura(pedido.Factura).Detalles)
                {
                    //Obtiene cada producto
                    var producto = _repoProducto.GetProducto(item.Producto);
                    datos += "<p>"+producto.Nombre + " x " + item.Cantidad+"</p>";
                }
                datos += "'},";
            }
            return datos;
        }

        //=========================================================================================
        //Cambia la lista dependiedo del valor que esté seleccionado en el Option Select
        public IActionResult OnPostCambiaLista()
        {
            //Captura el tipo de pedido a mostrar y lo guarda en una variable de sesión
            HttpContext.Session.SetInt32("lista", int.Parse(Request.Form["listaEstado"]));
            CargaPagina();
            return RedirectToPage("/Admin/Index");
        }

        //==========================================================================================
        //Captura el ID del pedido y cambia el estado sumando 1 al estado acutal
        public IActionResult OnPostCambiaEstado()
        {            
            var pedido = _repoPedidos.GetPedido(int.Parse(Request.Form["idpedido"]));//Captura el id del pedido
            _repoPedidos.UpdateEstadoPedido(pedido.Id); //Realiza el update del estado del pedido sumando 1 al estado actual
            CargaPagina();
            return RedirectToPage("/Admin/Index");
        }
        
        //===========================================================================================
        //Función para buscar un pedido en concreto... NO implementado
        //TODO
        public IActionResult OnPostBusca()
        {
            return RedirectToPage("/Admin/Index");
        }
    }
}