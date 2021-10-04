using System.Collections.Generic;
using System.Linq;
using ElGordo.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ElGordo.App.Persistencia.AppRepositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;
        public RepositorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Cliente IRepositorioCliente.AddCliente(Cliente cliente)
        {
            var nuevoCliente = _appContext.Cliente.Add(cliente);
            _appContext.SaveChanges();
            return nuevoCliente.Entity;
        }

        void IRepositorioCliente.DeleteCliente(int idCliente)
        {
            var clienteEliminar = _appContext.Cliente.FirstOrDefault(p => p.Id == idCliente);
            if (clienteEliminar == null) return;
            _appContext.Cliente.Remove(clienteEliminar);
            _appContext.SaveChanges();
        }

        IEnumerable<Cliente> IRepositorioCliente.GetAllClientes()
        {
            return _appContext.Cliente.Include(p => p.Id).Include(p => p.Nombre).Include(p => p.Telefono).AsNoTracking();
        }

        Cliente IRepositorioCliente.GetCliente(int idCliente)
        {
            return _appContext.Cliente.AsNoTracking().Include(p => p.Nombre).SingleOrDefault(p => p.Id == idCliente);
        }

        Cliente IRepositorioCliente.UpdateCliente(Cliente Cliente)
        {
            var clienteActualizar = _appContext.Cliente.FirstOrDefault(p => p.Id == Cliente.Id);
            if (clienteActualizar != null)
            {
                clienteActualizar.Nombre = Cliente.Nombre;
                clienteActualizar.Latitud = Cliente.Latitud;
                clienteActualizar.Longitud = Cliente.Longitud;
                clienteActualizar.Telefono = Cliente.Telefono;
                _appContext.SaveChanges();
            }
            return clienteActualizar;
        }
    }
}