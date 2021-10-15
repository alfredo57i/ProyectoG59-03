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
    public class ListaProductosModel : PageModel
    {
        private readonly IRepositorioProductos _repProducto;
        public IEnumerable<Producto> Productos { get; set; }

        public ListaProductosModel()
        {
            this.Productos = _repProducto.GetAll();
            this._repProducto = new RepositorioProductos(new ElGordo.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            Productos = _repProducto.GetAll();
        }

        public void OnPost(int productoId, int estadoId)
        {
            if (estadoId == 1)
            {
                _repProducto.CambiaEstado(productoId, 2);
            }
            else
            {
                _repProducto.CambiaEstado(productoId, 1);
            }
        }

    }
}