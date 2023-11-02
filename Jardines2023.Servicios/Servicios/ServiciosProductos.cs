using Jardines2023.Comun.Interfaces;
using Jardines2023.Datos;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Dtos.Producto;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        public ServiciosProductos()
        {
        }
        public void Borrar(int productoId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    unitOfWork.Productos.Borrar(productoId);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    unitOfWork?.Rollback();
                    throw;
                }
            }
        }
        public List<ProductoListDto> GetProductos(int? categoriaId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    var lista = unitOfWork.Productos.GetProductos(categoriaId);
                    return lista;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public int GetCantidad(int? categoriaId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    return unitOfWork.Productos.GetCantidad(categoriaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Existe(Producto producto)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    return unitOfWork.Productos.Existe(producto);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Guardar(Producto producto)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    string nuevoNombreArchivo = null;
                    if (producto.Imagen != null && !TryStrToGuid(producto.Imagen))
                    {
                        nuevoNombreArchivo = ObtenerNombreArchivo(Path.GetFileName(producto.Imagen));
                        File.Copy(producto.Imagen, Environment.CurrentDirectory + $@"\Imagenes\{nuevoNombreArchivo}");
                        producto.Imagen = nuevoNombreArchivo;
                    }

                    if (producto.ProductoId == 0)
                    {

                        unitOfWork.Productos.Agregar(producto);

                    }
                    else
                    {
                        unitOfWork.Productos.Editar(producto);
                    }
                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    unitOfWork.Rollback();
                    unitOfWork.Dispose();
                    throw;
                }
            }
        }
        private string ObtenerNombreArchivo(string imagen)
        {
            var array = imagen.Split('.');
            var extension = array[1];
            var nombre = Guid.NewGuid().ToString();
            return $"{nombre}.{extension}";
        }
        public bool TryStrToGuid(string s)
        {
            try
            {
                Guid value = new Guid(s);
                return true;
            }
            catch (FormatException)
            {
                Guid value = Guid.Empty;
                return false;
            }
        }


        public List<ProductoListDto> GetProductosPorPagina(int registrosPorPagina, int paginaActual, int?categoriaId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    return unitOfWork.Productos.GetProductosPorPagina(registrosPorPagina, paginaActual, categoriaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Producto GetProductoPorId(int productoId)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    return unitOfWork.Productos.GetProductoPorId(productoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }



        public bool EstaRelacionado(Producto producto)
        {
            using (var unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MiConexion"].ToString()))
            {

                try
                {
                    return unitOfWork.Productos.EstaRelacionado(producto);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
