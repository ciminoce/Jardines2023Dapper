using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Dtos.Proveedor;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Jardines2023.Comun.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private string cadenaConexion;
        public RepositorioProveedores()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Borrar(int ProveedorId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM Proveedores WHERE ProveedorId=@ProveedorId";
                conn.Execute(deleteQuery, new { ProveedorId });
            }

        }

        public void Editar(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Proveedores SET NombreProveedor=@NombreProveedor,
                                Direccion=@Direccion, 
                                CodigoPostal=@CodPostal, PaisId=@PaisId, 
                                CiudadId=@CiudadId, Email=@Email, 
                                TelefonoFijo=@TelefonoFijo, TelefonoMovil=@TelefonoMovil 
                                WHERE ProveedorId=@ProveedorId";
                conn.Execute(updateQuery, proveedor);
            }

        }

        public bool Existe(Proveedor proveedor)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (proveedor.ProveedorId == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Proveedores
                         WHERE NombreProveedor=@Nombre";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Nombre = proveedor.NombreProveedor });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Proveedores
                        WHERE NombreProveedor=@Nombre AND ProveedorId=@ProveedorId";
                    cantidad = conn.ExecuteScalar<int>(
                            selectQuery, new
                            {
                                Nombre = proveedor.NombreProveedor,
                                ProveedorId = proveedor.ProveedorId
                            });

                }
            }
            return cantidad > 0;
        }


        public int GetCantidad(int? paisId, int? ciudadId)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Proveedores";
                if (paisId == null)
                {
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (ciudadId == null)
                {
                    selectQuery += " WHERE PaisId=@PaisId";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { PaisId = paisId });

                }
                else
                {
                    selectQuery += " WHERE PaisId=@PaisId AND CiudadId=@CiudadId";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { PaisId = paisId, CiudadId = ciudadId });

                }
            }
            return cantidad;

        }

        public List<ProveedorListDto> GetProveedores(int? paisId, int? ciudadId)
        {
            List<ProveedorListDto> lista = new List<ProveedorListDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (paisId == null)
                {
                    string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                            FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                            INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                            ORDER BY NombreProveedor";
                    lista = conn.Query<ProveedorListDto>(selectQuery).ToList();
                }
                else if (ciudadId == null)
                {
                    string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                            FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                            INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                            WHERE Proveedores.PaisId=@PaisId                            
                            ORDER BY NombreProveedor";
                    lista = conn.Query<ProveedorListDto>(selectQuery, new { PaisId = paisId.Value }).ToList();

                }
                else
                {
                    string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                            FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                            INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                            WHERE Proveedores.PaisId=@PaisId AND Proveedores.CiudadId=@CiudadId                            
                            ORDER BY NombreProveedor";
                    lista = conn.Query<ProveedorListDto>(selectQuery, new
                    {
                        PaisId = paisId.Value,
                        CiudadId = ciudadId.Value
                    }).ToList();

                }
            }
            return lista;
        }

        public List<ProveedorListDto> GetProveedoresPorPagina(int cantidad, int paginaActual, int? paisId, int? ciudadId)
        {
            List<ProveedorListDto> lista = new List<ProveedorListDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (paisId == null)
                {
                    string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                        FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                        INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                        ORDER BY NombreProveedor
                        OFFSET @registrosSaltados ROWS 
                        FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    lista = conn.Query<ProveedorListDto>(selectQuery, new
                    {
                        registrosSaltados = cantidad * (paginaActual - 1),
                        cantidadPorPagina = cantidad

                    }).ToList();

                }
                else if (ciudadId != null)
                {
                    string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                        FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                        INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                        WHERE Proveedores.PaisId=@PaisId AND Proveedores.CiudadId=@CiudadId
                        ORDER BY NombreProveedor
                        OFFSET @registrosSaltados ROWS 
                        FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    lista = conn.Query<ProveedorListDto>(selectQuery, new
                    {
                        registrosSaltados = cantidad * (paginaActual - 1),
                        cantidadPorPagina = cantidad,
                        PaisId = paisId.Value,
                        CiudadId = ciudadId.Value

                    }).ToList();

                }
                else
                {
                    string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                        FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                        INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                        WHERE Proveedores.PaisId=@PaisId
                        ORDER BY NombreProveedor
                        OFFSET @registrosSaltados ROWS 
                        FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    lista = conn.Query<ProveedorListDto>(selectQuery, new
                    {
                        registrosSaltados = cantidad * (paginaActual - 1),
                        cantidadPorPagina = cantidad,
                        PaisId = paisId.Value

                    }).ToList();

                }
            }
            return lista;

        }

        public void Agregar(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string addQuery = @"INSERT INTO Proveedores (NombreProveedor, 
                                Direccion, CodigoPostal, PaisId, CiudadId,
                                Email, TelefonoFijo, TelefonoMovil)
                                VALUES (@Nombre, @Direccion,
                                @CodPostal, @PaisId, @CiudadId, @Email,
                                @TelefonoFijo, @TelefonoMovil);
                                SELECT SCOPE_IDENTITY()";


                int id = conn.ExecuteScalar<int>(addQuery, proveedor);
                proveedor.ProveedorId = id;
            }

        }


        public Proveedor GetProveedorPorId(int ProveedorId)
        {
            Proveedor proveedor = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT ProveedorId, NombreProveedor, Direccion, CodigoPostal,
                        TelefonoFijo, TelefonoMovil,
                        PaisId, CiudadId, Email 
                        FROM Proveedores WHERE ProveedorId=@ProveedorId";
                proveedor = conn.QuerySingleOrDefault<Proveedor>(selectQuery, ProveedorId);
            }
            return proveedor;

        }



        public bool EstaRelacionado(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorComboDto> GetProveedoresCombo()
        {
            List<ProveedorComboDto> lista = new List<ProveedorComboDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT ProveedorId, NombreProveedor 
                            FROM Proveedores                         
                            ORDER BY NombreProveedor";
                lista = conn.Query<ProveedorComboDto>(selectQuery).ToList();

            }
            return lista;
        }
    }
}
