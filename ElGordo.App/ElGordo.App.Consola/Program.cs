using System;
using System.Text.Json;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;

namespace ElGordo.App.Consola
{
    class Program
    {
        private static IRepositorioProductos _repoProducto = new RepositorioProductos(new App.Persistencia.AppContext());
        private static IRepositorioEstadoProducto _repoEstadoProducto = new RepositorioEstadoProducto(new App.Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //AgregaProducto();

            _repoProducto.CambiaEstado(1, 1);

            foreach (var item in _repoEstadoProducto.GetAllEstadosProducto())
            {
                Console.WriteLine(item.Nombre);

            }
            //Console.WriteLine(_repoEstadoProducto.GetEstadoProducto(1).Nombre);
            _repoEstadoProducto.AddEstadoProducto(new EstadoProducto{Nombre= "Descontinuado"});
        }

        private static void AgregaProducto()
        {
            var producto = new Producto
            {
                //Id=1,
                Nombre = "Hamburguesa",
                Estado = _repoEstadoProducto.GetEstadoProducto(1),
                Descripcion = "Hamburguesa everywhere",
                Imagen = "hamburguesa.jpg",
                Precio = 15000,
            };
            Console.WriteLine(JsonSerializer.Serialize(producto));
            //_repoProducto.AddProducto(producto);
            //_repoProducto.UpdateProducto(producto); 
        }
    }
}
