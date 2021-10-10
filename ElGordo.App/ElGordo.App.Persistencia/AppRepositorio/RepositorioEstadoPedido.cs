using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia
{
    public class RepositorioEstadoPedido : IRepositorioEstadoPedido
    {
        private readonly AppContext _appContext;
        public RepositorioEstadoPedido(AppContext appContext)
        {
            _appContext = appContext;
        }
        public EstadoPedido AddEstadoPedido(EstadoPedido estado)
        {
            var nuevoEstado = _appContext.EstadoPedido.Add(estado);
            _appContext.SaveChanges();
            return nuevoEstado.Entity;
        }

        public void DeleteEstadoPedido(int idEstado)
        {
            var estadoEliminar = _appContext.EstadoPedido.FirstOrDefault(e => e.Id == idEstado);
            if (estadoEliminar == null) return;
            _appContext.EstadoPedido.Remove(estadoEliminar);
            _appContext.SaveChanges();
        }

        public IEnumerable<EstadoPedido> GetAllEstadosPedido()
        {
            return _appContext.EstadoPedido;
        }

        public EstadoPedido GetEstadoPedido(int idEstado)
        {
            return _appContext.EstadoPedido.SingleOrDefault(e => e.Id == idEstado);
        }

        public EstadoPedido UpdateEstadoPedido(EstadoPedido estado)
        {
            var estadoActualizar = _appContext.EstadoPedido.FirstOrDefault(e=>e.Id==estado.Id);
            if(estadoActualizar!=null)
            {
                estadoActualizar.Nombre=estado.Nombre;
                _appContext.SaveChanges();
            }
            return estadoActualizar;
        }
    }
}