using System.ComponentModel.DataAnnotations;

namespace ElGordo.App.Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No es un nombre válido"), StringLength(50)]
        public string Nombre { get; set; }
        public EstadoProducto Estado { get; set; }
        public float Precio { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una imagen")]
        public string Imagen { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Agregue una descripción")]
        public string Descripcion { get; set; }
    }
}
