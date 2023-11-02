using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Jardines2023.Comun.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        private readonly string cadenaConexion;
        public RepositorioPaises()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }


        public void Agregar(Pais pais)
        {
            using (IDbConnection conn = new SqlConnection(cadenaConexion))
            {

                string insertQuery = "INSERT INTO Paises (NombrePais) VALUES(@NombrePais); SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, pais);
                pais.PaisId = id;

            }
        }
        public void Borrar(int paisId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM Paises WHERE PaisId=@PaisId";
                conn.Execute(deleteQuery, new { paisId });
            }
        }
        public void Editar(Pais pais)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {

                string updateQuery = "UPDATE Paises SET NombrePais=@NombrePais WHERE PaisId=@PaisId";
                conn.Execute(updateQuery, pais);
            }
        }

        public int GetCantidad(string textoFiltro = null)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (textoFiltro == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Paises";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Paises WHERE NombrePais LIKE @textoFiltro";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { textoFiltro });

                }
            }
            return cantidad;

        }

        public bool Existe(Pais pais)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (pais.PaisId == 0)
                {
                    selectQuery = "SELECT COUNT(*) FROM Paises WHERE NombrePais=@NombrePais";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, pais);
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Paises WHERE NombrePais=@NombrePais AND PaisId!=@PaisId";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, pais);
                }
            }
            return cantidad > 0;
        }

        public Pais GetPaisPorId(int paisId)
        {
            Pais pais = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT PaisId, NombrePais FROM Paises WHERE PaisId=@PaisId";
                pais = conn.QueryFirstOrDefault<Pais>(selectQuery, new { paisId });
            }
            return pais;
        }

        public List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro = null)
        {
            List<Pais> lista = new List<Pais>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (textoFiltro == null)
                {
                    selectQuery = @"SELECT PaisId, NombrePais FROM Paises
                        ORDER BY NombrePais 
                        OFFSET @cantidadRegistros ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    lista = conn.Query<Pais>(selectQuery, new
                    {
                        cantidadRegistros = cantidad * (paginaActual - 1),
                        cantidadPorPagina = cantidad
                    }).ToList();
                }
                else
                {
                    selectQuery = @"SELECT PaisId, NombrePais FROM Paises WHERE NombrePais LIKE @textoFiltro
                        ORDER BY NombrePais 
                        OFFSET @cantidadRegistros ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    lista = conn.Query<Pais>(selectQuery, new
                    {
                        cantidadRegistros = cantidad * (paginaActual - 1),
                        cantidadPorPagina = cantidad,
                        textoFiltro = textoFiltro
                    }).ToList();

                }
            }
            return lista;
        }

        public List<Pais> GetPaises(string textoFiltro = null)
        {
            List<Pais> lista = new List<Pais>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (textoFiltro!= null)
                {
                    selectQuery = @"SELECT PaisId, NombrePais FROM Paises
                            WHERE UPPER(NombrePais) LIKE @textoFiltro ORDER BY NombrePais";
                    textoFiltro = $"{textoFiltro.ToUpper()}%";
                    lista = conn.Query<Pais>(selectQuery, new { textoFiltro }).ToList();
                
                }
                else
                {
                    selectQuery = @"SELECT PaisId, NombrePais FROM Paises
                             ORDER BY NombrePais";
                    lista = conn.Query<Pais>(selectQuery).ToList();

                }
            }
            return lista;

        }

        public bool EstaRelacionado(Pais pais)
        {
            int cantidad = 0;
            using (IDbConnection conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Ciudades WHERE PaisId=@PaisId";
                cantidad = conn.QuerySingle<int>(selectQuery, new { PaisId = pais.PaisId });
            }
            return cantidad > 0;
        }
    }
}
