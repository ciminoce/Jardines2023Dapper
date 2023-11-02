using Jardines2023.Datos;
using Jardines2023.Entidades.Dtos.Categoria;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosCategorias : IServiciosCategorias
    {

        public ServiciosCategorias()
        {

        }
        public void Borrar(int categoriaId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    unitOfWork.Categorias.Borrar(categoriaId);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    unitOfWork?.Rollback();
                    throw;
                }
            }
        }
        public List<Categoria> GetCategorias()
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    var lista = unitOfWork.Categorias.GetCategorias();
                    return lista;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public int GetCantidad()
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    var cantidad = unitOfWork.Categorias.GetCantidad();
                    return cantidad;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Existe(Categoria categoria)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    bool existe = unitOfWork.Categorias.Existe(categoria);
                    return existe;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Guardar(Categoria categoria)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {
                try
                {
                    // Realiza operaciones en el repositorio
                    if(categoria.CategoriaId == 0)
                    {
                        unitOfWork.Categorias.Agregar(categoria);

                    }
                    else
                    {
                        unitOfWork.Categorias.Editar(categoria);

                    }

                    // Más operaciones si es necesario

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


        public List<Categoria> GetCategoriasPorPagina(int cantidad, int pagina)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    var lista = unitOfWork.Categorias.GetCategoriasPorPagina(cantidad, pagina);
                    return lista;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CategoriaComboDto> GetCategoriasCombos()
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    return unitOfWork.Categorias.GetCategoriasCombos();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
