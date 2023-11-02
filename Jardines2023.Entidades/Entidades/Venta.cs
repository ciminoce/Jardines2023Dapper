using Jardines2023.Entidades.Enum;
using System;
using System.Collections.Generic;

namespace Jardines2023.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public string TransaccionId { get; set; }
        public decimal Total { get; set; }
        public EstadoOrden EstadoOrden { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
        public Cliente Cliente { get; set; }

    }
}
