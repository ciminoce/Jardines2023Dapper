using Jardines2023.Comun.Interfaces;
using Jardines2023.Comun.Repositorios;
using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repositorio;
        public ServiciosCiudades()
        {
            _repositorio = new RepositorioCiudades();
        }
        public void Borrar(int ciudadId)
        {
            try
            {
                _repositorio.Borrar(ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Ciudad ciudad)
        {
            try
            {
                return _repositorio.EstaRelacionada(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repositorio.Existe(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? paisId)
        {
            try
            {
                return _repositorio.GetCantidad(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<CiudadDto> GetCiudades(int? paisId)
        {
            try
            {
                return _repositorio.GetCiudades(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<CiudadComboDto> GetCiudadesCombos(int paisId)
        {
            try
            {
                return _repositorio.GetCiudadesCombos(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CiudadDto> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual, int? paisId)
        {
            try
            {
                var lista = _repositorio.GetCiudadesPorPagina(registrosPorPagina, paginaActual, paisId);
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            try
            {
                return _repositorio.GetCiudadPorId(ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    _repositorio.Agregar(ciudad);
                }
                else
                {
                    _repositorio.Editar(ciudad);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
