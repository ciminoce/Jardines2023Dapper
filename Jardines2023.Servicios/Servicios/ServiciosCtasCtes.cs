using Jardines2023.Datos;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosCtasCtes : IServiciosCtasCtes
    {
        public ServiciosCtasCtes()
        {
            
        }
        public List<MovimientoCtaCte> GetMovimientos(int clienteId)
        {
            List<MovimientoCtaCte> lista= null;
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    lista=unitOfWork.CtaCtes.GetMovimientos(clienteId);
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public decimal GetSaldo(int clienteId)
        {
            decimal saldo = 0;
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    saldo = unitOfWork.CtaCtes.GetSaldo(clienteId);
                    return saldo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Guardar(MovimientoCtaCte movimientoCtaCte)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    unitOfWork.CtaCtes.Agregar(movimientoCtaCte);
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    // Maneja errores y posiblemente realiza un rollback
                    unitOfWork.Rollback();
                    unitOfWork.Dispose();
                    // Log o manejo de errores
                }
            }

        }
    }
}
