using System.ComponentModel.DataAnnotations;
namespace ElGordo.App.Dominio
{
    public class EstadoPedido
    {
        public int Id{get;set;}
        [Required(ErrorMessage = "No es un nombre válido"), StringLength(20)]
        public string Nombre{get;set;}
        public string Abreviacion { get; set; }
    }
}