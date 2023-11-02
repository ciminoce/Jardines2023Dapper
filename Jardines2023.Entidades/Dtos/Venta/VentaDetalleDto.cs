using Jardines2023.Entidades.Dtos.DetalleVenta;
using System;
using System.Collections.Generic;

namespace Jardines2023.Entidades.Dtos.Venta
{
    public class VentaDetalleDto
    {
        public VentaListDto ventaListDto { get; set; }
        public List<DetalleVentaDto> DetallesDto { get; set; }
    }
}
