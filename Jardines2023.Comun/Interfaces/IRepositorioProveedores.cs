using Jardines2023.Entidades.Dtos.Proveedor;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioProveedores
    {
        void Agregar(Proveedor Proveedor);
        void Borrar(int proveedorId);
        void Editar(Proveedor proveedor);
        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
        int GetCantidad(int? paisId, int? ciudadId);
        List<ProveedorListDto> GetProveedores(int? paisId, int? ciudadId);
        List<ProveedorListDto> GetProveedoresPorPagina(int registrosPorPagina, int paginaActual, int? paisId, int? ciudadId);
        Proveedor GetProveedorPorId(int proveedorId);
        List<ProveedorComboDto> GetProveedoresCombo();
    }
}
