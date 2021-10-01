namespace ElGordo.App.Dominio
{
    public class Producto
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public EstadoProducto Estado{get;set;}
        public float Precio{get;set;}
        public string Imagen{get;set;}
        public string Descripcion{get;set;}
    }
}