using System.Collections.Generic;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public interface IRepositorioUsuario
    {
        IEnumerable<EstadoProducto> GetAll();
        Usuario GetUsuario(int idUsuario);
        Usuario Login(string usuario, string password);
        Usuario AddUsuario(Usuario user);
        Usuario UpdateUsuario(Usuario user);
        void DeleteUsuario(int user);
    }
}