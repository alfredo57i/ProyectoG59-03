using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioPedido
    {
         IEnumerable<Pedido> GetAll();
         IEnumerable<Pedido> GetPedidoPorEstado(int filtro);
         IEnumerable<Pedido> GetPorCodigo(string codigo);
         Pedido GetPedido(int pedidoId);
         Pedido AddPedido(Pedido pedido);
         Pedido UpdatePedido(Pedido pedido);
         void DeletePedido(int idPedido);         
    }
}