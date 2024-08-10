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
    public class FamiliaRepositorio : Repositorio<Familia>, IFamiliaRepositorio
    {
        private readonly AppDBContext _db;

        public FamiliaRepositorio(AppDBContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<int> ActualizarFamilia(Familia familia)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@IdFamilia", familia.IdFamilia));
            parametro.Add(new SqlParameter("@FamiliaNombre", familia.Nombre));
            parametro.Add(new SqlParameter("@IdClase", familia.IdClase));


            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec ActualizarFamilia @IdFamilia, @FamiliaNombre, @IdClase", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> AgregarFamilia(Familia familia)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@FamiliaNombre", familia.Nombre));
            parametro.Add(new SqlParameter("@IdClase", familia.IdClase));

            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec AgregarFamilia @FamiliaNombre, @IdClase", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> EliminarFamilia(int idFamilia)
        {
            return await Task.Run(() => _db.Database.ExecuteSqlInterpolatedAsync($"EliminarFamilia {idFamilia}"));
        }

        public async Task<IEnumerable<FamiliaDTO>> ObtenerFamiliaId(int id)
        {
            var param = new SqlParameter("@ClaseId", id);

            var sql = FormattableStringFactory.Create("EXEC ObtenerFamiliaClaseId @ClaseId", param);

            return _db.Database
                .SqlQuery<FamiliaDTO>(sql);
        }

        public async Task<List<FamiliaDTO>> ObtenerLista()
        {
            var sql = FormattableStringFactory.Create("EXEC ObtenerListaFamilias");

            return await _db.Database
                .SqlQuery<FamiliaDTO>(sql)
                .ToListAsync();
        }
    }
}
