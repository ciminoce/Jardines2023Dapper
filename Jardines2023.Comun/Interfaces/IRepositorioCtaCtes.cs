using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioCtaCtes
    {
        void Agregar(MovimientoCtaCte ctaCte);
        List<MovimientoCtaCte> GetMovimientos(int clienteId);
        decimal GetSaldo(int clienteId);
    }
}
