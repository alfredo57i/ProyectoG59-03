using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia.AppRepositorio
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

        void IRepositorioDetalle.DeleteDetalle(int idDetalle)
        {
            var DetalleEliminar = _appContext.Detalle.FirstOrDefault(p => p.Id == idDetalle);
            if (DetalleEliminar == null) return;
            _appContext.Detalle.Remove(DetalleEliminar);
            _appContext.SaveChanges();
        }

        IEnumerable<Detalle> IRepositorioDetalle.GetAllDetalles()
        {
            return _appContext.Detalle.Include(p => p.Id).Include(p => p.Producto).Include(p => p.Cantidad).Include(p => p.Precio).Include(p => p.Impuesto).AsNoTracking();
        }

        IEnumerable<Detalle> IRepositorioDetalle.GetAllProductos()
        {
            throw new System.NotImplementedException();
        }

        Detalle IRepositorioDetalle.GetDetalle(int idDetalle)
        {
            return _appContext.Detalle.AsNoTracking().Include(p => p.Precio).SingleOrDefault(p => p.Id == idDetalle);
        }

        float IRepositorioDetalle.GetPrecio()
        {
            
            throw new System.NotImplementedException();
        }

        //Detalle IRepositorioDetalle.GetFactura(int idDetalle)
        //{
        //    throw new System.NotImplementedException();
        //}

        Detalle IRepositorioDetalle.UpdateDetalle(Detalle detalle)
        {
            var detalleActualizar = _appContext.Detalle.FirstOrDefault(p => p.Id == detalle.Id);
            if (detalleActualizar != null)
            {
                detalleActualizar.Producto = detalle.Producto;
                detalleActualizar.Precio = detalle.Precio;
                detalleActualizar.Cantidad = detalle.Cantidad;
                detalleActualizar.Impuesto = detalle.Impuesto;
                _appContext.SaveChanges();
            }
            return detalleActualizar;
        }
    }
}