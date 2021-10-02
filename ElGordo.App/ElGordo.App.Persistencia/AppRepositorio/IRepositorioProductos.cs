using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioProductos
    {
         IEnumerable<Producto> GetAll();
         IEnumerable<Producto> GetDisponibles(int filtro);
         IEnumerable<Producto> GetPorFiltro(string filtro);
         Producto GetProducto(int productoId);
         Producto AddProducto(Producto producto);
         Producto UpdateProducto(Producto producto);
         Producto CambiaEstado(int productoId,int nuevoEstado);
         void DeleteProducto(int idProducto);
    }
}