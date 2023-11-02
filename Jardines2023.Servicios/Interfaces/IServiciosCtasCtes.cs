using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosCtasCtes
    {
        void Guardar(MovimientoCtaCte movimientoCtaCte);
        List<MovimientoCtaCte> GetMovimientos(int clienteId);
        decimal GetSaldo(int clienteId);
    }
}