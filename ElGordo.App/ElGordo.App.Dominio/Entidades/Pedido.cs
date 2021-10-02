using System;

namespace ElGordo.App.Dominio
{
    public class Pedido
    {
        public int Id{get;set;}
        public string Codigo{get;set;}
        public string Cliente{get;set;}
        public Factura Factura{get;set;}
        public EstadoPedido Estado{get;set;}
        public float LatitudEntrega{get;set;}
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