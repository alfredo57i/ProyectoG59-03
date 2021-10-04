using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia.AppRepositorio
{
    public interface IRepositorioFactura
    {
        IEnumerable<Factura> GetAllFacturas();
        Factura AddFactura(Factura factura);
        Factura UpdateFactura(Factura factura);
        void DeleteFactura(int idFactura);
        Factura GetFactura(int idFactura);

    }
}