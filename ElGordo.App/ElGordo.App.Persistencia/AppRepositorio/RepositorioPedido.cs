using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly AppContext _appContext;
        public RepositorioPedido(AppContext appContext)
        {
            _appContext = appContext;
        }
        public Pedido AddPedido(Pedido pedido)
        {
            var nuevoPedido = _appContext.Pedido.Add(pedido);
            _appContext.SaveChanges();
            return nuevoPedido.Entity;
        }

        public void DeletePedido(int idPedido)
        {
            var pedidoEliminar = _appContext.Pedido.FirstOrDefault(p => p.Id == idPedido);
            if (pedidoEliminar == null) return;
            _appContext.Pedido.Remove(pedidoEliminar);
            _appContext.SaveChanges();
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _appContext.Pedido.Include(p => p.Factura).Include(p => p.Estado).Include(p => p.Cliente).AsNoTracking();
        }

        public IEnumerable<Pedido> GetPedidoPorEstado(int filtro)
        {
            var pedidoFind = GetAll();
            if (pedidoFind != null)
            {
                pedidoFind = pedidoFind.Where(p => p.Estado.Id == filtro);
            }
            return pedidoFind;
        }

        public Pedido GetPedido(int pedidoId)
        {
            return _appContext.Pedido.AsNoTracking().Include(p => p.Estado).SingleOrDefault(p => p.Id == pedidoId);
        }

        public IEnumerable<Pedido> GetPorCodigo(string codigo)
        {
            var pedidoFind = GetAll();
            if (pedidoFind != null)
            {
                if (!string.IsNullOrEmpty(codigo))//Si el la variable "filtro" contiene algun texto
                {
                    pedidoFind = pedidoFind.Where(p => p.Codigo == codigo);
                }
            }
            return pedidoFind;
        }

        public Pedido UpdatePedido(Pedido pedido)
        {
            var pedidoActualizar = _appContext.Pedido.FirstOrDefault(p => p.Id == pedido.Id);
            if (pedidoActualizar != null)
            {
                pedidoActualizar.Estado = pedido.Estado;
                pedidoActualizar.Fecha_pedido = pedido.Fecha_pedido;
                pedidoActualizar.Fecha_preparacion = pedido.Fecha_preparacion;
                pedidoActualizar.Fecha_envio = pedido.Fecha_envio;
                pedidoActualizar.Fecha_entrega = pedido.Fecha_entrega;
                _appContext.SaveChanges();
            }
            return pedidoActualizar;
        }
    }
}