using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public class RepositorioEstadoFactura : IRepositorioEstadoFactura
    {
        private readonly AppContext _appContext;
        public RepositorioEstadoFactura(AppContext appContext)
        {
            _appContext = appContext;
        }
        public EstadoFactura AddEstadoFactura(EstadoFactura estado)
        {
            var nuevoEstado = _appContext.EstadoFactura.Add(estado);
            _appContext.SaveChanges();
            return nuevoEstado.Entity;
        }

        public void DeleteEstadoFactura(int idEstado)
        {
            var estadoEliminar = _appContext.EstadoFactura.FirstOrDefault(e => e.Id == idEstado);
            if (estadoEliminar == null) return;
            _appContext.EstadoFactura.Remove(estadoEliminar);
            _appContext.SaveChanges();
        }

        public IEnumerable<EstadoFactura> GetAllEstadosFactura()
        {
            return _appContext.EstadoFactura;
        }

        public EstadoFactura GetEstadoFactura(int idEstado)
        {
            return _appContext.EstadoFactura.SingleOrDefault(e => e.Id == idEstado);
        }

        public EstadoFactura UpdateEstadoFactura(EstadoFactura estado)
        {
            var estadoActualizar = _appContext.EstadoFactura.FirstOrDefault(e=>e.Id==estado.Id);
            if(estadoActualizar!=null)
            {
                estadoActualizar.Nombre=estado.Nombre;
                _appContext.SaveChanges();
            } 
            return estadoActualizar;
        }
    }
}