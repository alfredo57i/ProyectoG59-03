using System;
using System.ComponentModel.DataAnnotations;
namespace ElGordo.App.Dominio
{
    public class Pedido
    {
        public int Id{get;set;}
        public string Codigo{get;set;}
        [Required(ErrorMessage = "No es un nombre válido")]
        public string Cliente{get;set;}
        public int Factura{get;set;}
        public int Estado{get;set;}
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public float LatitudEntrega{get;set;}
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public float LongitudEntrega{get;set;}
        public float LatitudActual{get;set;}
        public float LongitudActual{get;set;}
        public string Notas{get;set;}
        public DateTime Fecha_pedido{get;set;}
        public DateTime? Fecha_preparacion{get;set;}
        public DateTime? Fecha_envio{get;set;}
        public DateTime? Fecha_entrega{get;set;}
    }
}