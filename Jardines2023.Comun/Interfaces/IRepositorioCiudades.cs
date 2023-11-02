using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioCiudades
    {
        void Agregar(Ciudad ciudad);
        void Borrar(int ciudadId);
        void Editar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        bool EstaRelacionada(Ciudad ciudad);
        int GetCantidad(int? paisId);
        List<CiudadDto> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual, int? paisId);
        Ciudad GetCiudadPorId(int ciudadId);
        List<CiudadDto> GetCiudades(int? paisId);

        List<CiudadComboDto> GetCiudadesCombos(int paisId);
    }
}
