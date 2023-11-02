using Jardines2023.Datos;
using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        public ServiciosVentas()
        {

        }

        public int GetCantidad()
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    return unitOfWork.Ventas.GetCantidad();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public VentaDetalleDto GetVentaDetalle(int ventaId)
        {
            VentaDetalleDto ventaDetalleDto = new VentaDetalleDto();
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    ventaDetalleDto.ventaListDto = unitOfWork.Ventas.GetVentaPorId(ventaId);
                    ventaDetalleDto.DetallesDto = unitOfWork.DetalleVentas.GetDetalleVenta(ventaId);
                    return ventaDetalleDto;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        public VentaListDto GetVentaPorId(int ventaId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    return unitOfWork.Ventas.GetVentaPorId(ventaId);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public List<VentaListDto> GetVentas()
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    return unitOfWork.Ventas.GetVentas();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

		public List<VentaListDto> GetVentasPorFecha(DateTime fecha)
		{
			using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
			{
				try
				{
					return unitOfWork.Ventas.GetVentasPorFecha(fecha);
				}
				catch (Exception ex)
				{

					throw ex;
				}
			}
		}

		public List<VentaListDto> GetVentasPorPagina(int registrosPorPagina, int paginaActual)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    return unitOfWork.Ventas.GetVentasPorPagina(registrosPorPagina, paginaActual);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void Guardar(Venta venta)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    unitOfWork.Ventas.Guardar(venta);

                    foreach (var itemVenta in venta.Detalles)
                    {
                        itemVenta.VentaId = venta.VentaId;
                        unitOfWork.DetalleVentas.Guardar(itemVenta);
                        unitOfWork.Productos.ActualizarStock(itemVenta.ProductoId, itemVenta.Cantidad);
                    }

                    var saldoEnCuenta = unitOfWork.CtaCtes.GetSaldo(venta.ClienteId);

                    var ctaCte = new MovimientoCtaCte
                    {
                        FechaMovimiento = DateTime.Now,
                        Movimiento = $"Vta Nro. {venta.VentaId}",
                        Debe = venta.Total,
                        Haber = 0,
                        Saldo = saldoEnCuenta + venta.Total,
                        ClienteId = venta.ClienteId
                    };
                    unitOfWork.CtaCtes.Agregar(ctaCte);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    unitOfWork.Rollback();
                    unitOfWork.Dispose();
                    throw new Exception("Joder no anduvo!!!");
                }

            }
        }
    }
}
