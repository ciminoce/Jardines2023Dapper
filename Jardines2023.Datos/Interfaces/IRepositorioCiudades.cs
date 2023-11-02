using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Datos.Interfaces
{
    public interface IRepositorioCiudades
    {
        void Agregar(Ciudad ciudad);
        void Borrar(int ciudadId);
        void Editar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        int GetCantidad();
        List<Ciudad> GetCiudades();
        List<Ciudad> GetCiudadesPorPagina(int cantidad, int paginaActual);

    }
}
