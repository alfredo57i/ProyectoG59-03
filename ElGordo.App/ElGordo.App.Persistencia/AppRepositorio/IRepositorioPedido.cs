using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioPedido
    {
         IEnumerable<Pedido> GetAll();
         IEnumerable<Pedido> GetPendientes();
         IEnumerable<Pedido> GetPedidoPorEstado(int filtro);
         Pedido GetPorCodigo(string codigo);
         Pedido GetPedido(int pedidoId);
         Pedido AddPedido(Pedido pedido);
         Pedido UpdateEstadoPedido(int idPedido);
    }
}