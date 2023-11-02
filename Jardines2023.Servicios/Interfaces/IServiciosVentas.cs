using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosVentas
    {
        void Guardar(Venta venta);
        List<VentaListDto> GetVentas();
        List<VentaListDto> GetVentasPorPagina(int registrosPorPagina, int paginaActual);
        VentaListDto GetVentaPorId(int ventaId);
        VentaDetalleDto GetVentaDetalle(int ventaId);
		int GetCantidad();
		List<VentaListDto> GetVentasPorFecha(DateTime fecha);
	}
}
