using Dapper;
using Jardines2023.Datos.Interfaces;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Datos.RepositoriosDapper
{
    public class RepositorioPaisesDapper : IRepositorioPaises
    {
        private readonly string cadenaConexion;
        public RepositorioPaisesDapper()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["Miconexion"].ToString(); 
        }
        public void Agregar(Pais pais)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int paisId)
        {
            throw new NotImplementedException();
        }

        public void Editar(Pais pais)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Pais pais)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<Pais> GetPaises()
        {
            using (IDbConnection con=new SqlConnection(cadenaConexion))
            {
                var selectQuery = "SELECT PaisId, NombrePais FROM Paises ORDER BY NombrePais";
                List<Pais> lista=con.Query<Pais>(selectQuery).ToList();
                return lista;
            }
        }

        public Pais GetPaisPorId(int paisId)
        {
            throw new NotImplementedException();
        }
    }
}
