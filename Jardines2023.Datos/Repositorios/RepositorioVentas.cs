using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly IDbTransaction _transaction;
        public RepositorioVentas(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            string selectQuery = @"SELECT COUNT(*) FROM Ventas";
            cantidad = _transaction.Connection.QuerySingle<int>(selectQuery, transaction: _transaction);
            return cantidad;
        }

		

		public VentaListDto GetVentaPorId(int ventaId)
        {


            string selectQuery = @"SELECT VentaId, FechaVenta, Nombres+' '+Apellido as Cliente,
                    Direccion+' '+CodigoPostal AS Domicilio,
                    TransaccionId, 
                    Total, EstadoOrden FROM Ventas INNER JOIN Clientes 
                    ON Ventas.ClienteId=Clientes.ClienteId 
                    WHERE VentaId=@VentaId";
            var ventaDto = _transaction.Connection
                .QuerySingle<VentaListDto>(selectQuery,
                new { @VentaId = ventaId }, transaction: _transaction);
            return ventaDto;
        }

        public List<VentaListDto> GetVentas()
        {
            List<VentaListDto> lista = new List<VentaListDto>();

            string selectQuery = @"SELECT VentaId, FechaVenta, Nombres+' '+Apellido as Cliente, TransaccionId, 
                    Total, EstadoOrden FROM Ventas INNER JOIN Clientes 
                    ON Ventas.ClienteId=Clientes.ClienteId 
                    ORDER BY FechaVenta";
            lista = _transaction.Connection.Query<VentaListDto>(selectQuery, transaction: _transaction).ToList();
            return lista;
        }

		public List<VentaListDto> GetVentasPorFecha(DateTime fecha)
		{
			List<VentaListDto> lista = new List<VentaListDto>();

			string selectQuery = @"SELECT VentaId, FechaVenta, Nombres+' '+Apellido as Cliente, TransaccionId, 
                    Total, EstadoOrden FROM Ventas INNER JOIN Clientes 
                    ON Ventas.ClienteId=Clientes.ClienteId 
                    WHERE CAST(CAST(FechaVenta as date) AS datetime)=@FechaFiltro
                    ORDER BY FechaVenta";
			lista = _transaction.Connection.Query<VentaListDto>(selectQuery,new { @FechaFiltro = fecha }, transaction: _transaction).ToList();
			return lista;
		}

		public List<VentaListDto> GetVentasPorPagina(int registrosPorPagina, int paginaActual)
        {
            List<VentaListDto> lista = new List<VentaListDto>();

            string selectQuery = @"SELECT VentaId, FechaVenta, Nombres+' '+Apellido as Cliente, TransaccionId, 
                    Total, EstadoOrden FROM Ventas INNER JOIN Clientes 
                    ON Ventas.ClienteId=Clientes.ClienteId 
                    ORDER BY FechaVenta 
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidadPorPagina ROWS ONLY";
            lista = _transaction.Connection.Query<VentaListDto>(selectQuery, new
            {
                cantidadPorPagina = registrosPorPagina,
                cantidadRegistros = registrosPorPagina * (paginaActual - 1)
            }, transaction: _transaction).ToList();
            return lista;
        }

		public List<VentaListDto> GetVentasPorPagina(int registrosPorPagina, int paginaActual, Func<Venta, bool> filtro = null)
		{
			throw new NotImplementedException();
		}

		public void Guardar(Venta venta)
        {
            string insertQuery = @"INSERT INTO Ventas (FechaVenta, ClienteId, TransaccionId, Total, EstadoOrden)
                        VALUES(@FechaVenta, @ClienteId, @TransaccionId, @Total, @EstadoOrden); 
                        SELECT SCOPE_IDENTITY()";
            int id = _transaction.Connection.QuerySingle<int>(insertQuery, venta, transaction: _transaction);
            venta.VentaId = id;

        }
    }
}
