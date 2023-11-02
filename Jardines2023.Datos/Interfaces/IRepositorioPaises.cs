using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Datos.Interfaces
{
    public interface IRepositorioPaises
    {
        void Agregar(Pais pais);
        void Borrar(int paisId);
        void Editar(Pais pais);
        bool Existe(Pais pais);
        int GetCantidad();
        List<Pais> GetPaises();
        Pais GetPaisPorId(int paisId);
    }
}