using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioClientes
    {
        void Borrar(int clienteId);
        void Editar(Cliente cliente);
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        int GetCantidad(int? paisId, int? ciudadId);
        List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual, int? paisId, int? ciudadId);
        void Agregar(Cliente cliente);
        Cliente GetClientePorId(int clienteId);
        List<ClienteListDto> GetClientes(int? paisId, int? ciudadId);
    }
}
