using System;
using System.Collections.Generic;

namespace ElGordo.App.Dominio
{
    public class Factura
    {
        public int Id{get;set;}
        public int Numero{get;set;}
        public DateTime Fecha{get;set;}
        public EstadoFactura Estado{get;set;}
        public List<Detalle> Detalles{get;set;}
    }
}