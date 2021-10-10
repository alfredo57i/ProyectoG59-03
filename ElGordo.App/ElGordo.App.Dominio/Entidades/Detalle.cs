using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGordo.App.Dominio
{
    public class Detalle
    {
        public int Id{get;set;}
        public int Producto{get;set;}
        public float Precio{get;set;}
        public int Cantidad{get;set;}
        //public float Impuesto{get;set;}
    }
}