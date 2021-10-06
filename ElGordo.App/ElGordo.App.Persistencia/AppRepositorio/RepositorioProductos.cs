using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia
{
    public class RepositorioProductos : IRepositorioProductos
    {

        private readonly AppContext _appContext;
        public RepositorioProductos(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Producto AddProducto(Producto producto)
        {
            var nuevoProducto = _appContext.Producto.Add(producto);
            _appContext.SaveChanges();
            return nuevoProducto.Entity;
        }

        public Producto CambiaEstado(int productoId,int nuevoEstado)
        {
            var productoActualizar = _appContext.Producto.FirstOrDefault(p=>p.Id==productoId);
            if(productoActualizar!=null)
            {
                productoActualizar.Estado=_appContext.EstadoProducto.FirstOrDefault(ep=>ep.Id==nuevoEstado);
                _appContext.SaveChanges();
            } 
            return productoActualizar;
        }

        public void DeleteProducto(int idProducto)
        {
            var productoEliminar = _appContext.Producto.FirstOrDefault(p => p.Id == idProducto);
            if (productoEliminar == null) return;
            _appContext.Producto.Remove(productoEliminar);
            _appContext.SaveChanges();
        }

        public IEnumerable<Producto> GetAll()
        {
            return _appContext.Producto.Include(p=>p.Estado).AsNoTracking();
        }

        public IEnumerable<Producto> GetDisponibles(int filtro)
        {
            var productosFind = GetAll();
            if (productosFind != null)
            {
                productosFind = productosFind.Where(pf => pf.Estado.Id == filtro);
            }
            return productosFind;
        }

        public IEnumerable<Producto> GetPorFiltro(string filtro = null)
        {
            var productosFind = GetAll();
            if (productosFind != null)
            {
                if (!string.IsNullOrEmpty(filtro))//Si el la variable "filtro" contiene algun texto
                {
                    productosFind = productosFind.Where(pf => pf.Nombre.Contains(filtro));
                }
            }
            return productosFind;
        }

        public Producto GetProducto(int productoId)
        {           
            return _appContext.Producto.AsNoTracking().Include(p=>p.Estado).SingleOrDefault(p => p.Id == productoId);
        }

        public Producto UpdateProducto(Producto producto)
        {
            var productoActualizar = _appContext.Producto.FirstOrDefault(p=>p.Id==producto.Id);
            if(productoActualizar!=null)
            {
                productoActualizar.Nombre=producto.Nombre;
                productoActualizar.Estado=producto.Estado;
                productoActualizar.Precio=producto.Precio;
                productoActualizar.Imagen=producto.Imagen;
                productoActualizar.Descripcion=producto.Descripcion;
                _appContext.SaveChanges();
            }
            return productoActualizar;
        }
    }
}