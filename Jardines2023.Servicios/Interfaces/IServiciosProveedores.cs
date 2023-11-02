using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Dtos.Proveedor;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosProveedores
    {
        void Borrar(int proveedorId);
        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
        int GetCantidad(int? paisId, int? ciudadId);
        List<ProveedorListDto> GetProveedores(int? paisId, int? ciudadId);
        List<ProveedorListDto> GetProveedoresPorPagina(int registrosPorPagina, int paginaActual, int? paisId, int? ciudadId);
        Proveedor GetProveedorPorId(int proveedorId);
        void Guardar(Proveedor proveedor);
        List<ProveedorComboDto> GetProveedoresCombo();
    }
}
