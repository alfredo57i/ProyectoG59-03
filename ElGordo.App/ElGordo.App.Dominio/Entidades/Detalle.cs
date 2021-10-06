namespace ElGordo.App.Dominio
{
    public class Detalle
    {
        public int Id{get;set;}
        public Producto Producto{get;set;}
        public float Precio{get;set;}
        public int Cantidad{get;set;}
        public float Impuesto{get;set;}
    }
}