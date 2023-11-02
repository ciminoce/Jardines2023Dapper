using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Dtos.DetalleVenta;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioDetalleVentas : IRepositorioDetalleVentas
    {
        private readonly IDbTransaction _transaction;

        public RepositorioDetalleVentas(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public List<DetalleVentaDto> GetDetalleVenta(int ventaId)
        {
            List<DetalleVentaDto> lista = new List<DetalleVentaDto>();
            string selectQuery = @"SELECT p.NombreProducto, dv.PrecioUnitario, dv.Cantidad 
                        FROM DetallesVentas dv INNER JOIN Productos p
                        ON dv.ProductoId=p.ProductoId
                        WHERE dv.VentaId=@ventaId";

            lista = _transaction.Connection
               .Query<DetalleVentaDto>(selectQuery,
                   new { @ventaId },
               transaction: _transaction).ToList();
            return lista;
        }

        public void Guardar(DetalleVenta detalleVenta)
        {
            //string insertQuery = @"INSERT INTO DetalleVentas(VentaId, ProductoId, PrecioUnitario, Cantidad)
            //    VALUES(@VentaId, @ProductoId, @PrecioUnitario, @Cantidad)";
            string insertQuery = @"INSERT INTO DetallesVentas(VentaId, ProductoId, PrecioUnitario, Cantidad)
                VALUES(@VentaId, @ProductoId, @PrecioUnitario, @Cantidad)";
            _transaction.Connection.Execute(insertQuery, detalleVenta, transaction: _transaction);
        }
    }
}
