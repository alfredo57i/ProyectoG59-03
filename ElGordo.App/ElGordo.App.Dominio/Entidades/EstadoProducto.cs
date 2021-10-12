using System.ComponentModel.DataAnnotations;
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