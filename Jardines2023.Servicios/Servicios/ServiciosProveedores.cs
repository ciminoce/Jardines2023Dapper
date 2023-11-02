using Jardines2023.Comun.Interfaces;
using Jardines2023.Comun.Repositorios;
using Jardines2023.Entidades.Dtos.Proveedor;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosProveedores : IServiciosProveedores
    {
        private readonly IRepositorioProveedores _repositorio;
        public ServiciosProveedores()
        {
            _repositorio = new RepositorioProveedores();
        }

        public void Borrar(int proveedorId)
        {
            try
            {
                _repositorio.Borrar(proveedorId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                return _repositorio.Existe(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int GetCantidad(int? paisId, int? ciudadId)
        {
            try
            {
                return _repositorio.GetCantidad(paisId, ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }




        public Proveedor GetProveedorPorId(int proveedorId)
        {
            try
            {
                return _repositorio.GetProveedorPorId(proveedorId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProveedorListDto> GetProveedores(int? paisId, int? ciudadId)
        {
            try
            {
                return _repositorio.GetProveedores(paisId, ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProveedorListDto> GetProveedoresPorPagina(int registrosPorPagina, int paginaActual, int? paisId, int? ciudadId)
        {
            try
            {
                return _repositorio.GetProveedoresPorPagina(registrosPorPagina, paginaActual, paisId, ciudadId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    _repositorio.Agregar(proveedor);
                }
                else
                {
                    _repositorio.Editar(proveedor);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorComboDto> GetProveedoresCombo()
        {
            try
            {
                return _repositorio.GetProveedoresCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
