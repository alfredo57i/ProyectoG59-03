using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioEstadoPedido
    {
        IEnumerable<EstadoPedido> GetAllEstadosPedido();
        EstadoPedido AddEstadoPedido(EstadoPedido estado);
        EstadoPedido UpdateEstadoPedido(EstadoPedido estado);
        void DeleteEstadoPedido(int idEstado);
        EstadoPedido GetEstadoPedido(int idEstado);
    }
}