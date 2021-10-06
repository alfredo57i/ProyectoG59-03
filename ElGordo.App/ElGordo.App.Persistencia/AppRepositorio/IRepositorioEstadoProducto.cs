using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioEstadoProducto
    {
        IEnumerable<EstadoProducto> GetAllEstadosProducto();
        EstadoProducto AddEstadoProducto(EstadoProducto estado);
        EstadoProducto UpdateEstadoProducto(EstadoProducto estado);
        void DeleteEstadoProducto(int idEstado);
        EstadoProducto GetEstadoProducto(int idEstado);
    }
}