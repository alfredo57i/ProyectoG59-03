
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGordo.App.Dominio
{
    public class EstadoProducto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No es un nombre válido"), StringLength(20)]
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}