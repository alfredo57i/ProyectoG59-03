using Microsoft.EntityFrameworkCore;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public class AppContext : DbContext
    {
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
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =ElGordoDB");
            }
        }

        //Función que carga los datos por defecto para las tablas necesarias.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoProducto>().HasData(new EstadoProducto[] {
                new EstadoProducto{Id=1, Nombre="Disponible"},
                new EstadoProducto{Id=2, Nombre="NO Disponible"},
                new EstadoProducto{Id=3, Nombre="Descontinuado"},
            });
            modelBuilder.Entity<EstadoPedido>().HasData(new EstadoPedido[] {
                new EstadoPedido{Id=1, Nombre="Realizado"},
                new EstadoPedido{Id=2, Nombre="En Preparación"},
                new EstadoPedido{Id=3, Nombre="Enviado"},
                new EstadoPedido{Id=4, Nombre="Entregado"},
            });
            modelBuilder.Entity<EstadoFactura>().HasData(new EstadoFactura[] {
                new EstadoFactura{Id=1, Nombre="Aprobada"},
                new EstadoFactura{Id=2, Nombre="Anulada"},
            });
            modelBuilder.Entity<Usuario>().HasData(new Usuario[] {
                new Usuario{Id=1, Nickname="admin", Nombre="Administrador", Password = "admin"},
            });
        }
    }
}