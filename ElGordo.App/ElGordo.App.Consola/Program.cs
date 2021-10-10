using System;
using System.Text.Json;
using ElGordo.App.Dominio;
using ElGordo.App.Persistencia;

namespace ElGordo.App.Consola
{
    public static class Program
    {
        private static IRepositorioProductos _repoProducto = new RepositorioProductos(new App.Persistencia.AppContext());
        private static IRepositorioEstadoProducto _repEstadoProducto = new RepositorioEstadoProducto(new App.Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("No olvides sonreir");
        }

    }
}
