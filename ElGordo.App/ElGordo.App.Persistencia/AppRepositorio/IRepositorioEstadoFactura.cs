using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioEstadoFactura
    {
        IEnumerable<EstadoFactura> GetAllEstadosFactura();
        EstadoFactura AddEstadoFactura(EstadoFactura estado);
        EstadoFactura UpdateEstadoFactura(EstadoFactura estado);
        void DeleteEstadoFactura(int idEstado);
        EstadoFactura GetEstadoFactura(int idEstado);
    }
}