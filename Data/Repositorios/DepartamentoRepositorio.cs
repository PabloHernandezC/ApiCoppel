using Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        private readonly AppDBContext _db;

        public DepartamentoRepositorio(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Departamento>> ObtenerLista()
        {
            return await _db.Departamentos
                .FromSqlRaw<Departamento>("ObtenerListaDepartamentos")
                .ToListAsync();
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamentoId(int id)
        {
            var param = new SqlParameter("@DepartamentoId", id);

            var departamentoDetalles = await Task.Run(() => _db.Departamentos
                                        .FromSqlRaw(@"exec ObtenerDepartamentoId @DepartamentoId", param).ToListAsync());
            return departamentoDetalles;
        }

        public async Task<int> AgregarDepartamento(Departamento departamento)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@DepaNombre", departamento.Nombre));

            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec AgregarDepa @DepaNombre", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> ActualizarDepartamento(Departamento departamento)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@IdDepartamento", departamento.IdDepartamento));
            parametro.Add(new SqlParameter("@DepaNombre", departamento.Nombre));


            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec ActualizarDepa @IdDepartamento, @DepaNombre", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> EliminarDepartemento(int idDepartamento)
        {
            return await Task.Run(() => _db.Database.ExecuteSqlInterpolatedAsync($"EliminarDepa {idDepartamento}"));
        }
    }
}
