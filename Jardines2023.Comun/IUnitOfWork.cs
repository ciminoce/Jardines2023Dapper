using Jardines2023.Comun.Interfaces;
using System;

namespace Jardines2023.Comun
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IRepositorioCategorias Categorias { get; }
        IRepositorioCiudades Ciudades { get; }
        IRepositorioClientes Clientes { get; }
        IRepositorioProveedores Proveedores { get; }
        IRepositorioProductos Productos { get; }
        IRepositorioPaises Paises { get; }
        IRepositorioCiudades ClientesCiudades { get; }
        IRepositorioVentas Ventas { get; }
        IRepositorioDetalleVentas   DetalleVentas { get; }
        IRepositorioCtaCtes CtaCtes { get; }
    }
}
