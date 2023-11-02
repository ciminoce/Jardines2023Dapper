using Dapper;
using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Dtos.Categoria;
using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jardines2023.Comun.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly IDbTransaction _transaction;
        public RepositorioCategorias(IDbTransaction transaction)
        {
            _transaction = transaction;
        }


        public void Agregar(Categoria categoria)
        {
            string insertQuery = @"INSERT INTO Categorias (NombreCategoria, Descripcion)
                        VALUES(@NombreCategoria, @Descripcion); 
                        SELECT SCOPE_IDENTITY()";
            int id = _transaction.Connection.QuerySingle<int>(insertQuery, categoria, transaction:_transaction);
            categoria.CategoriaId = id;
        }
        public void Borrar(int categoriaId)
        {
            string deleteQuery = "DELETE FROM Categorias WHERE CategoriaId=@CategoriaId";
            _transaction.Connection.Execute(deleteQuery, new { CategoriaId = categoriaId }, transaction: _transaction);
        }
        public void Editar(Categoria categoria)
        {
            string updateQuery = @"UPDATE Categorias SET NombreCategoria=@NombreCategoria, 
                                Descripcion=@Descripcion WHERE CategoriaId=@CategoriaId";
            _transaction.Connection.Execute(updateQuery, categoria, transaction: _transaction);

        }
        public List<Categoria> GetCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            string selectQuery = "SELECT CategoriaId, NombreCategoria, Descripcion FROM Categorias ORDER BY NombreCategoria";
            lista = _transaction.Connection.Query<Categoria>(selectQuery, transaction: _transaction).ToList();
            return lista;
        }

        public int GetCantidad()
        {
            int cantidad = 0;

            string selectQuery = "SELECT COUNT(*) FROM Categorias";
            cantidad = _transaction.Connection.ExecuteScalar<int>(selectQuery, transaction: _transaction);
            return cantidad;

        }

        public bool Existe(Categoria categoria)
        {
            var cantidad = 0;
            string selectQuery;
            if (categoria.CategoriaId == 0)
            {
                selectQuery = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria=@NombreCategoria";

            }
            else
            {
                selectQuery = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria=@NombreCategoria AND CategoriaId<>@CategoriaId";

            }
            cantidad = _transaction.Connection.ExecuteScalar<int>(selectQuery, categoria, transaction: _transaction);
            return cantidad > 0;
        }

        public List<Categoria> GetCategoriasPorPagina(int cantidad, int pagina)
        {
            List<Categoria> lista = new List<Categoria>();
            string selectQuery = @"SELECT CategoriaId, NombreCategoria, Descripcion FROM Categorias
                ORDER BY NombreCategoria
                OFFSET @cantidadRegistros ROWS 
                FETCH NEXT @cantidadPorPagina ROWS ONLY";

            lista = _transaction.Connection.Query<Categoria>(selectQuery,
                new
                {
                    cantidadRegistros = (pagina - 1) * cantidad,
                    cantidadPorPagina = cantidad
                }, transaction: _transaction).ToList();
            return lista;
        }


        public bool EstaRelacionada(Categoria categoria)
        {
            int cantidad = 0;
            string selectQuery = "SELECT COUNT(*) FROM Productos WHERE CategoriaId=@CategoriaId";
            cantidad = _transaction.Connection.QuerySingle<int>(selectQuery, 
                new { CategoriaId = categoria.CategoriaId }, transaction: _transaction);
            return cantidad > 0;
        }

        public List<CategoriaComboDto> GetCategoriasCombos()
        {
            List<CategoriaComboDto> lista = new List<CategoriaComboDto>();
            string selectQuery = "SELECT CategoriaId, NombreCategoria FROM Categorias ORDER BY NombreCategoria";
            lista = _transaction.Connection.Query<CategoriaComboDto>(selectQuery, transaction: _transaction).ToList();
            return lista;

        }
    }
}
