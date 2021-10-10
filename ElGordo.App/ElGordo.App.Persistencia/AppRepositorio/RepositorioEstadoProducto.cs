using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia
{
    public class RepositorioEstadoProducto : IRepositorioEstadoProducto
    {
        private readonly AppContext _appContext;
        public RepositorioEstadoProducto(AppContext appContext)
        {
            _appContext = appContext;
        }
        public EstadoProducto AddEstadoProducto(EstadoProducto estado)
        {
            var nuevoEstado = _appContext.EstadoProducto.Add(estado);
            _appContext.SaveChanges();
            return nuevoEstado.Entity;
        }

        public void DeleteEstadoProducto(int idEstado)
        {
            var estadoEliminar = _appContext.EstadoProducto.FirstOrDefault(e => e.Id == idEstado);
            if (estadoEliminar == null) return;
            _appContext.EstadoProducto.Remove(estadoEliminar);
            _appContext.SaveChanges();
        }

        public IEnumerable<EstadoProducto> GetAllEstadosProducto()
        {
            return _appContext.EstadoProducto;
        }

        public EstadoProducto GetEstadoProducto(int idEstado)
        {
            //_appContext.ChangeTracker.AutoDetectChangesEnabled = true;
            return _appContext.EstadoProducto.SingleOrDefault(e => e.Id == idEstado);
        }

        public EstadoProducto UpdateEstadoProducto(EstadoProducto estado)
        {
            var estadoActualizar = _appContext.EstadoProducto.FirstOrDefault(e=>e.Id==estado.Id);
            if(estadoActualizar!=null)
            {
                estadoActualizar.Nombre=estado.Nombre;
                _appContext.SaveChanges();
            }
            return estadoActualizar;
        }
    }
}