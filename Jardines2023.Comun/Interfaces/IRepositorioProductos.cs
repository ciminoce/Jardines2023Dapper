using Jardines2023.Entidades.Dtos.Producto;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioProductos
    {
        void Agregar(Producto producto);
        void Borrar(int productoId);
        void Editar(Producto producto);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
        int GetCantidad(int? categoriaId);
        Producto GetProductoPorId(int productoId);
        List<ProductoListDto> GetProductos(int? categoriaId);
        List<ProductoListDto> GetProductosPorPagina(int cantidad, int pagina, int? categoriaId);
        void ActualizarStock(int productoId, int cantidad);
    }
}
