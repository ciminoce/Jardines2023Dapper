using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosPaises
    {
        void Guardar(Pais pais);
        void Borrar(int paisId);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
        //int GetCantidad();
        int GetCantidad(string textoFiltro);
        List<Pais> GetPaises(string textoFiltro);
        List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro);
        Pais GetPaisPorId(int paisId);
    }
}