using Jardines2023.Entidades.Enum;
using System;

namespace Jardines2023.Entidades.Dtos.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; }
        public string Domicilio{ get; set; }
        public string TransaccionId { get; set; }
        public decimal Total { get; set; }
        public EstadoOrden EstadoOrden { get; set; }
    }
}
