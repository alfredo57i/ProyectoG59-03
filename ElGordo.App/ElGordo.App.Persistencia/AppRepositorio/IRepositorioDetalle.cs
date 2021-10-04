using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia.AppRepositorio
{
    public interface IRepositorioDetalle
    {
        IEnumerable<Detalle> GetAllDetalles();
        IEnumerable<Detalle> GetAllProductos();

        Detalle AddDetalle(Detalle detalle);
        Detalle UpdateDetalle(Detalle detalle);
        void DeleteDetalle(int idDetalle);
        Detalle GetDetalle(int idDetalle);

        float GetPrecio();

        //Detalle GetFactura(int idDetalle);
    }
}