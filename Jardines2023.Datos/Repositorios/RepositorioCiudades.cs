using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Jardines2023.Comun.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {

        private readonly string cadenaConexion;
        public RepositorioCiudades()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }


        public void Agregar(Ciudad ciudad)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Ciudades (NombreCiudad, PaisId)
                    VALUES(@NombreCiudad, @PaisId); SELECT SCOPE_IDENTITY()";
                int id = conn.ExecuteScalar<int>(insertQuery, ciudad);
                ciudad.CiudadId = id;

            }
        }

        public void Borrar(int ciudadId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Ciudades 
                        WHERE CiudadId=@CiudadId";
                conn.Execute(deleteQuery, new { CiudadId = ciudadId });
            }

        }

        public void Editar(Ciudad ciudad)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Ciudades SET NombreCiudad=@NombreCiudad,
                    PaisId=@PaisId WHERE CiudadId=@CiudadId";
                conn.Execute(updateQuery, ciudad);
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (ciudad.CiudadId == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Ciudades
                        WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, ciudad);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Ciudades 
                            WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId 
                            AND CiudadId!=@CiudadId";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, ciudad);

                }
            }
            return cantidad > 0;
        }



        public int GetCantidad(int? paisId)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (paisId == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Ciudades";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Ciudades 
                        WHERE PaisId=@PaisId";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { PaisId = paisId });
                }
            }
            return cantidad;
        }


        public List<CiudadDto> GetCiudadesPorPagina(int cantidad, int paginaActual, int? paisId)
        {
            List<CiudadDto> lista = new List<CiudadDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (paisId == null)
                {
                    string selectQuery = @"SELECT CiudadId, NombreCiudad, NombrePais
                                FROM Ciudades INNER JOIN Paises 
                                ON Ciudades.PaisId=Paises.PaisId
                                ORDER BY Ciudades.PaisId, NombreCiudad
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<CiudadDto>(selectQuery, new
                    {
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();
                }
                else
                {
                    string selectQuery = @"SELECT CiudadId, NombreCiudad, NombrePais
                                FROM Ciudades INNER JOIN Paises 
                                ON Ciudades.PaisId=Paises.PaisId
                                WHERE Ciudades.PaisId=@PaisId
                                ORDER BY Ciudades.PaisId, NombreCiudad
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<CiudadDto>(selectQuery, new
                    {
                        PaisId = paisId.Value,
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();

                }
            }
            return lista;
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            Ciudad ciudad = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT CiudadId, NombreCiudad, PaisId 
                    FROM Ciudades WHERE CiudadId=@CiudadId";
                ciudad = conn.QuerySingleOrDefault<Ciudad>(selectQuery,
                    new { CiudadId = ciudadId });
            }
            return ciudad;
        }

        public List<CiudadDto> GetCiudades(int? paisId)
        {
            List<CiudadDto> lista = new List<CiudadDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (paisId == null)
                {
                    selectQuery = @"SELECT CiudadId, NombreCiudad, NombrePais FROM Ciudades
                        INNER JOIN Paises ON Ciudades.PaisId=Paises.PaisId
                        ORDER BY NombreCiudad";
                    lista = conn.Query<CiudadDto>(selectQuery).ToList();
                }
                else
                {
                    selectQuery = @"SELECT CiudadId, NombreCiudad, NombrePais FROM Ciudades
                        INNER JOIN Paises ON Ciudades.PaisId=Paises.PaisId
                        WHERE Ciudades.PaisId=@PaisId
                        ORDER BY NombreCiudad";
                    lista = conn.Query<CiudadDto>(selectQuery, new { PaisId = paisId }).ToList();
                }
            }
            return lista;
        }

        public bool EstaRelacionada(Ciudad ciudad)
        {
            int cantidadClientes = 0;
            int cantidadProveedores = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Clientes WHERE CiudadId=@ciudadId;
                                        SELECT COUNT(*) FROM Proveedores WHERE CiudadId=@ciudadId";
                using (var resultado = conn.QueryMultiple(selectQuery, new { CiudadId = ciudad.CiudadId }))
                {
                    cantidadClientes = resultado.Read<int>().First();
                    cantidadProveedores = resultado.Read<int>().First();
                }
            }
            return cantidadClientes + cantidadProveedores > 0;
        }

        public List<CiudadComboDto> GetCiudadesCombos(int paisId)
        {
            List<CiudadComboDto> lista;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT CiudadId, NombreCiudad FROM Ciudades
                        WHERE PaisId=@paisId ORDER BY NombreCiudad";
                lista = conn.Query<CiudadComboDto>(selectQuery, new { paisId }).ToList();

            }
            return lista;

        }
    }
}
