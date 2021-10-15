using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGrodo.App.Frontend.Pages
{
    public class IndexPedidoModel : PageModel
    {
        public IRepositorioPedido _repoPedido;
        public IRepositorioEstadoPedido _repoEstadoPedido;
        public IRepositorioFactura _repoFactura;
        public IRepositorioProductos _repoProducto;
        public Pedido Pedido{get;set;}
        public EstadoPedido EstadoPedido{get;set;}
        public Factura Factura{get;set;}

        //Constructor 
        public IndexPedidoModel()
        {
            this._repoPedido = new RepositorioPedido(new ElGordo.App.Persistencia.AppContext());
            this._repoEstadoPedido = new RepositorioEstadoPedido(new ElGordo.App.Persistencia.AppContext());
            this._repoFactura = new RepositorioFactura(new ElGordo.App.Persistencia.AppContext());
            this._repoProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        }
        public void OnGet(string codigo)
        {
            //Verifica si se envió un código por GET (?codigo=xxx)
            if (codigo==null)
            {
                //Si no hay un código crea un objeto vacio
                Pedido = new Pedido{};                
            }
            else
            {
                //Busca el código en la Base de Datos
                Pedido = _repoPedido.GetPorCodigo(codigo);
                //Verifica si la base de datos devolvió un Pedido.
                if(Pedido==null){
                    //Si el código no es válido crea un objeto vacio y envía el mensaje de error a la vista.
                    Pedido = new Pedido{};
                    ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>El pedido <strong>"+codigo+"</strong> no existe</span>");                                        
                }else{
                    //Si hay un pedido válido se busca el estado del pedido.
                    EstadoPedido = _repoEstadoPedido.GetEstadoPedido(Pedido.Estado);
                    Factura = _repoFactura.GetFactura(Pedido.Factura);
                    ViewData["latitud"] = Pedido.LatitudEntrega;
                    ViewData["longitud"] = Pedido.LongitudEntrega;
                }
            }            
        }
    }
}