using Jardines2023.Comun;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Comun.Repositorios;
using Jardines2023.Entidades.Entidades;
using System.Data.SqlClient;
using System.Data;
using System;
using Jardines2023.Datos.Repositorios;

namespace Jardines2023.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public IRepositorioCategorias Categorias { get; }
        public IRepositorioCiudades Ciudades { get; }
        public IRepositorioClientes Clientes { get; }
        public IRepositorioProveedores Proveedores { get; }
        public IRepositorioProductos Productos { get; }
        public IRepositorioPaises Paises { get; }
        public IRepositorioCiudades ClientesCiudades { get; }
        public IRepositorioVentas Ventas { get; }
        public IRepositorioDetalleVentas DetalleVentas { get; }

        public IRepositorioCtaCtes CtaCtes {get; }

        public UnitOfWork(string cadenaConexion)
        {
            if (string.IsNullOrWhiteSpace(cadenaConexion))
            {
                throw new ArgumentException("La cadena de conexión no puede estar vacía.", nameof(cadenaConexion));
            }

            _connection = new SqlConnection(cadenaConexion);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            Categorias = new RepositorioCategorias(_transaction);
            Productos = new RepositorioProductos(_transaction);
            Ventas = new RepositorioVentas(_transaction);
            DetalleVentas = new RepositorioDetalleVentas(_transaction);
            Clientes=new RepositorioClientes(_transaction);
            CtaCtes=new RepositorioCtasCtes(_transaction);
        }


        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
