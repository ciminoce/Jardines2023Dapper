using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioCtasCtes : IRepositorioCtaCtes
    {
        private readonly IDbTransaction _transaction;
        public RepositorioCtasCtes(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        public List<MovimientoCtaCte> GetMovimientos(int clienteId)
        {
            List<MovimientoCtaCte> lista = new List<MovimientoCtaCte>();
            string selectQuery = @"SELECT CtaCteId, FechaMovimiento, Movimiento, Debe, 
                Haber, Saldo, ClienteId FROM CtasCtes
                WHERE ClienteId=@clienteId ORDER BY FechaMovimiento";
            lista = _transaction.Connection.Query<MovimientoCtaCte>(selectQuery,
                new { @clienteId }, transaction: _transaction).ToList();

            return lista;

        }

        public void Agregar(MovimientoCtaCte ctaCte)
        {
            string insertQuery = @"INSERT INTO CtasCtes (FechaMovimiento, 
                Movimiento, Debe, Haber, Saldo,ClienteId)
                        VALUES(@FechaMovimiento, @Movimiento, @Debe, @Haber, @Saldo, @ClienteId); 
                        SELECT SCOPE_IDENTITY()";
            int id = _transaction.Connection.QuerySingle<int>(insertQuery, 
                ctaCte, transaction: _transaction);
            ctaCte.CtaCteId = id;

        }

        public decimal GetSaldo(int clienteId)
        {
            string selectQuery = @"SELECT SUM(Debe-Haber) as Saldo 
                FROM CtasCtes WHERE ClienteId=@clienteId";
            var saldo = _transaction.Connection.ExecuteScalar<decimal>(selectQuery, new { @clienteId }, transaction: _transaction);

            return saldo;

        }
    }
}
