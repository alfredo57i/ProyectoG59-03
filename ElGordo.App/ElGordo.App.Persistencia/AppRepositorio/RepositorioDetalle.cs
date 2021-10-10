using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia
{
    public class RepositorioDetalle : IRepositorioDetalle
    {
        private readonly AppContext _appContext;
        public RepositorioDetalle(AppContext appContext)
        {
            _appContext = appContext;
        }

        Detalle IRepositorioDetalle.AddDetalle(Detalle detalle)
        {
            var nuevoDetalle = _appContext.Detalle.Add(detalle);
            _appContext.SaveChanges();
            return nuevoDetalle.Entity;
        }
        Detalle IRepositorioDetalle.GetDetalle(int idFactura)
        {
            return _appContext.Detalle.SingleOrDefault(p => p.Id == idFactura);
        }

        
    }
}