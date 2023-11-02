using Jardines2023.Entidades.Dtos.DetalleVenta;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioDetalleVentas
    {
        List<DetalleVentaDto> GetDetalleVenta(int ventaId);
        void Guardar(DetalleVenta detalleVenta);
    }
}
