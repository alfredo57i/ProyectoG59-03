using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioFactura
    {
        IEnumerable<Factura> GetAllFacturas();
        Factura AddFactura(Factura factura);
        Factura UpdateEstadoFactura(int idFactura, int estado);

        Factura GetFactura(int idFactura);

    }
}