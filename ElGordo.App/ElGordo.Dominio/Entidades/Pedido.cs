using System;

namespace ElGordo.Dominio
{
    public class Pedido
    {
        public int Id{get;set;}
        public Cliente Cliente{get;set;}
        public Factura Factura{get;set;}
        public EstadoPedido Estado{get;set;}
        public float Latitud{get;set;}
        public float Longitud{get;set;}
        public string Notas{get;set;}
        public DateTime Fecha_pedido{get;set;}
        public DateTime Fecha_preparacion{get;set;}
        public DateTime Fecha_envio{get;set;}
        public DateTime Fecha_entrega{get;set;}
    }
}