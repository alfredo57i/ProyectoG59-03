using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia
{
    public class RepositorioFactura : IRepositorioFactura
    {
        private readonly AppContext _appContext;
        public RepositorioFactura (AppContext appContext)
        {
            _appContext = appContext;
        }
        
        Factura IRepositorioFactura.AddFactura(Factura factura)
        {
            var nuevoFactura = _appContext.Factura.Add(factura);
            _appContext.SaveChanges();
            return nuevoFactura.Entity;
        }

        IEnumerable<Factura> IRepositorioFactura.GetAllFacturas()
        {
            return _appContext.Factura.Include(p => p.Id).Include(p => p.Numero).Include(p => p.Fecha).Include(p => p.Estado).Include(p => p.Detalles).AsNoTracking();
        }

        Factura IRepositorioFactura.GetFactura(int idFactura)
        {
            return _appContext.Factura.AsNoTracking().Include(p => p.Numero).SingleOrDefault(p => p.Id == idFactura);
        }

        Factura IRepositorioFactura.UpdateEstadoFactura(int idFactura, int estado)
        {
            var facturaEstadoActualizar = _appContext.Factura.FirstOrDefault(p => p.Id == idFactura);
            if (facturaEstadoActualizar == null) return null;
            facturaEstadoActualizar.Estado = _appContext.EstadoFactura.FirstOrDefault(p => p.Id == estado);
            _appContext.SaveChanges();
            return facturaEstadoActualizar;
        }
    }
}