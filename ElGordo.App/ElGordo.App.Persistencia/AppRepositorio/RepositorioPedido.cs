using System;
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

        public Pedido UpdateEstadoPedido(int idPedido,int idEstado)
        {
            var pedidoActualizar = _appContext.Pedido.FirstOrDefault(p => p.Id == idPedido);
            if (pedidoActualizar != null)
            {
                pedidoActualizar.Estado = _appContext.EstadoPedido.FirstOrDefault(e=>e.Id==idEstado);
                if(idEstado==2){
                    pedidoActualizar.Fecha_preparacion = DateTime.Now;
                }
                else if(idEstado==3)
                {
                    pedidoActualizar.Fecha_envio = DateTime.Now;
                }
                else{
                    pedidoActualizar.Fecha_entrega = DateTime.Now;
                }
                _appContext.SaveChanges();
            }
            return pedidoActualizar;
        }
    }
}