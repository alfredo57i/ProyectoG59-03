using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using ElGordo.App.Dominio;
using Newtonsoft.Json;
using System.Text.Json;
using ElGordo.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ElGrodo.App.Frontend.Pages
{
    public class PagoModel : PageModel
    {
        //Se agregan asignan los repositorios necesarios a variables para acceder a sus metodos
        private static readonly IRepositorioProductos _repoProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioPedido _repoPedido = new RepositorioPedido(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioFactura _repoFactura = new RepositorioFactura(new ElGordo.App.Persistencia.AppContext());        
        private static readonly IRepositorioEstadoPedido _repoEstadoPedido = new RepositorioEstadoPedido(new ElGordo.App.Persistencia.AppContext());
        private static readonly IRepositorioEstadoFactura _repoEstadoFactura = new RepositorioEstadoFactura(new ElGordo.App.Persistencia.AppContext());
        
        //Se crean las lista y variables necesarias para generar los datos del pedido
        public List<Carrito> ListaCarrito { get; set; }
        public Pedido Pedido { get; set; }
        public Factura Factura{get;set;}
        public int Total { get; set; }
        public List<Detalle> ListaDetalles{get;set;}

        //Método principal que se ejecuta al cargar la Página.
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("carrito") == null || HttpContext.Session.GetString("carrito") == "[]"||HttpContext.Session.GetString("pedido") == null || HttpContext.Session.GetString("pedido") == "[]")
            {
                return RedirectToPage("/Index");//Si no existen las variables "carrito" o "pedido" se redirige a la pantalla principal.
            }   

            //Se convierte el string del carrito(Varaible de sesión) en una lista de Objetos tipo "Carrito"
            ListaCarrito = JsonConvert.DeserializeObject<List<Carrito>>(HttpContext.Session.GetString("carrito"));
            //Se convierte el string del pedido(Varaible de sesión) en un Objeto de tipo Pedido
            Pedido = JsonConvert.DeserializeObject<Pedido>(HttpContext.Session.GetString("pedido"));

            //Se eliminan las variables de sesión
            HttpContext.Session.Remove("carrito");
            HttpContext.Session.Remove("pedido");

            //Se asigna el estado del pedido a "Realizado" y se agrega la fecha y hora actual
            Pedido.Estado = 1;//Se asigna el estado como Realizado
            //Se asigna DateTime a todas las fechas para evitar valores nulos 
            Pedido.Fecha_pedido = DateTime.Now;
            Pedido.Fecha_preparacion = DateTime.Now;
            Pedido.Fecha_envio = DateTime.Now;
            Pedido.Fecha_entrega = DateTime.Now;

            //Se ejecuta la función encargada de guardar los datos en la BD 
            GuardaDatosBD();      

            //Se envian los Ojetos a la vista.
            ViewData["JsonCarrito"] = System.Text.Json.JsonSerializer.Serialize(ListaCarrito);
            ViewData["JsonPedido"] = System.Text.Json.JsonSerializer.Serialize(Pedido);
            return Page();
        }

        //Funcion que guarda todo en la Base de Datos.
        public void GuardaDatosBD()
        {
            //Se ejecuta la función que generar los detalles y la factura
            GenerarFactura();
            Factura FacturaBD = _repoFactura.AddFactura(Factura); 
            if(FacturaBD!=null){
                Pedido.Factura= FacturaBD.Id; 
            }
            Pedido = _repoPedido.AddPedido(Pedido); 
        }

        //Funcion que genera la factura, Recorre la lista del carrito 
        //genera los Detalles para enviarlos a la base de datos 
        public void GenerarFactura()
        {
            ListaDetalles = new List<Detalle>();
            Total = 0;
            foreach (var item in ListaCarrito)
            {
                var newDetalle = new Detalle{
                    Producto = item.Id,
                    Precio = _repoProducto.GetProducto(item.Id).Precio,
                    Cantidad = item.Cantidad
                };                    
                ListaDetalles.Add(newDetalle);//Se agrega un detalle a lista por cada item de la "ListaCarrito"
                Total += item.Precio * item.Cantidad;//Se calcula el Total de la factura.
            }
            //Se asignan los atributos a la Factura
            Factura = new Factura{ 
                Estado = 1,
                Fecha = DateTime.Now,
                Detalles = ListaDetalles    
            };
        }        
    }
}