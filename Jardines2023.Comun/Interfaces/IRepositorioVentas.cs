using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioVentas
    {
        int GetCantidad();
        VentaListDto GetVentaPorId(int ventaId);
        List<VentaListDto> GetVentas();
		List<VentaListDto> GetVentasPorFecha(DateTime fecha);
		List<VentaListDto> GetVentasPorPagina(int registrosPorPagina, int paginaActual);
        void Guardar(Venta venta);
    }
}
