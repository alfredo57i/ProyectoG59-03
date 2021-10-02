using Microsoft.EntityFrameworkCore;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public class AppContext : DbContext
    {
        //public DbSet<Cliente> Cliente{get;set;}
        public DbSet<EstadoProducto> EstadoProducto{get;set;}
        public DbSet<Producto> Producto{get;set;}
        public DbSet<Detalle> Detalle{get;set;}
        public DbSet<EstadoFactura> EstadoFactura{get;set;}
        public DbSet<Factura> Factura{get;set;}
        public DbSet<EstadoPedido> EstadoPedido{get;set;}
        public DbSet<Pedido> Pedido{get;set;}
        public DbSet<Usuario> Usuario{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =ElGordoData");
            }
        }        
    }
}