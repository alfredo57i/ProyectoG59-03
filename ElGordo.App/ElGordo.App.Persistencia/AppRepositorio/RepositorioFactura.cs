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
            var nuevaFactura = _appContext.Factura.Add(factura);
            _appContext.SaveChanges();
            return nuevaFactura.Entity;
        }

        IEnumerable<Factura> IRepositorioFactura.GetAllFacturas()
        {
            return _appContext.Factura.Include(f=>f.Detalles).AsNoTracking().OrderBy(f=>f.Fecha);
        }

        Factura IRepositorioFactura.GetFactura(int idFactura)
        {
            return _appContext.Factura.Include(f=>f.Detalles).SingleOrDefault(p => p.Id == idFactura);
        }

        Factura IRepositorioFactura.UpdateEstadoFactura(int idFactura, int estado)
        {
            var facturaEstadoActualizar = _appContext.Factura.FirstOrDefault(p => p.Id == idFactura);
            if (facturaEstadoActualizar == null) return null;
            facturaEstadoActualizar.Estado = estado;
            _appContext.SaveChanges();
            return facturaEstadoActualizar;
        }
    }
}