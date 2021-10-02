using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AppContext _appContext;
        public RepositorioUsuario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Usuario AddUsuario(Usuario user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUsuario(int user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EstadoProducto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Usuario Login(string usuario, string password)
        {
            var user =  _appContext.Usuario.SingleOrDefault(p => p.Nickname == usuario);
            if(user!=null){
                if(user.Password==password){return user;}
                return null;
            }else{
                return null;
            }
        }

        public Usuario UpdateUsuario(Usuario user)
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetUsuario(int idUsuario)
        {
            return _appContext.Usuario.SingleOrDefault(u => u.Id == idUsuario);
        }
    }
}