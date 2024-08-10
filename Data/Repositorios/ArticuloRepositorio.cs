using Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class ArticuloRepositorio : Repositorio<Articulo>, IArticuloRepositorio
    {
        private readonly AppDBContext _db;

        public ArticuloRepositorio(AppDBContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<int> Actualizar(Articulo articulo)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@SKU", articulo.Sku));
            parametro.Add(new SqlParameter("@Articulo", articulo.Article));
            parametro.Add(new SqlParameter("@Marca", articulo.Marca));
            parametro.Add(new SqlParameter("@Modelo", articulo.Modelo));
            parametro.Add(new SqlParameter("@IdDepartamento", articulo.IdDepartamento));
            parametro.Add(new SqlParameter("@IdClase", articulo.IdClase));
            parametro.Add(new SqlParameter("@IdFamilia", articulo.IdFamilia));
            parametro.Add(new SqlParameter("@FechaAlta", articulo.FechaAlta));
            parametro.Add(new SqlParameter("@Stock", articulo.Stock));
            parametro.Add(new SqlParameter("@Cantidad", articulo.Cantidad));
            parametro.Add(new SqlParameter("@Descontinuado", articulo.Descontinuado));
            parametro.Add(new SqlParameter("@FechaBaja", articulo.FechaBaja));



            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec ActualizarArticulo @SKU, @Articulo, @Marca, 
                                @Modelo, @IdDepartamento, @IdClase, @IdFamilia, @FechaAlta, @Stock, 
                                @Cantidad, @Descontinuado, @FechaBaja", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> AgregarArticulo(Articulo articulo)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@SKU", articulo.Sku));
            parametro.Add(new SqlParameter("@Articulo", articulo.Article));
            parametro.Add(new SqlParameter("@Marca", articulo.Marca));
            parametro.Add(new SqlParameter("@Modelo", articulo.Modelo));
            parametro.Add(new SqlParameter("@IdDepartamento", articulo.IdDepartamento));
            parametro.Add(new SqlParameter("@IdClase", articulo.IdClase));
            parametro.Add(new SqlParameter("@IdFamilia", articulo.IdFamilia));
            parametro.Add(new SqlParameter("@FechaAlta", articulo.FechaAlta));
            parametro.Add(new SqlParameter("@Stock", articulo.Stock));
            parametro.Add(new SqlParameter("@Cantidad", articulo.Cantidad));
            parametro.Add(new SqlParameter("@Descontinuado", articulo.Descontinuado));
            parametro.Add(new SqlParameter("@FechaBaja", articulo.FechaBaja));



            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec AgregarArticulo @SKU, @Articulo, @Marca, 
                                @Modelo, @IdDepartamento, @IdClase, @IdFamilia, @FechaAlta, @Stock, 
                                @Cantidad, @Descontinuado, @FechaBaja", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> Eliminar(int id)
        {
            return await Task.Run(() => _db.Database.ExecuteSqlInterpolatedAsync($"EliminarArticulo {id}"));
        }

        public async Task<List<ArticuloDTO>> ObtenerLista()
        {
            var sql = FormattableStringFactory.Create("EXEC ObtenerListaArticulo");

            return await _db.Database
                .SqlQuery<ArticuloDTO>(sql)
                .ToListAsync();
        }

        public async Task<IEnumerable<ArticuloDTO>> ObtenerSKU(int id)
        {
            var param = new SqlParameter("@SKU", id);

            var sql = FormattableStringFactory.Create("EXEC ObtenerArticuloSku @SKU", param);

            return _db.Database
                .SqlQuery<ArticuloDTO>(sql);
        }
    }
}
