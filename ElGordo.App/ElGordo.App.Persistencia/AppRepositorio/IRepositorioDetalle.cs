using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioDetalle
    {

        Detalle AddDetalle(Detalle detalle);

        Detalle GetDetalle(int idFactura);
    }
}