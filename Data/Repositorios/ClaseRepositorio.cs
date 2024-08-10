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
    public class ClaseRepositorio : Repositorio<Clase>, IClaseRepositorio
    {
        private readonly AppDBContext _db;

        public ClaseRepositorio(AppDBContext db) : base(db)
        {
            _db = db;
        }

        /*public void Actualizar(Clase clase)
        {
            var claseDB = _db.Clases.FirstOrDefault(e => e.IdClase == clase.IdClase);
            if (claseDB != null)
            {
                claseDB.Nombre = clase.Nombre;
                claseDB.IdClase = clase.IdClase;
                _db.SaveChanges();
            }
        }*/

        public async Task<List<ClaseDTO>> ObtenerLista()
        {
            var sql = FormattableStringFactory.Create("EXEC ObtenerListaClases");

            return await _db.Database
                .SqlQuery<ClaseDTO>(sql)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClaseDTO>> ObtenerClaseId(int id)
        {

            var param = new SqlParameter("@DepartamentoId", id);

            var sql = FormattableStringFactory.Create("EXEC ObtenerClaseDepaId @DepartamentoId", param);

            return _db.Database
                .SqlQuery<ClaseDTO>(sql);
        }

        public async Task<int> AgregarClase(Clase Clase)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@ClaseNombre", Clase.Nombre));
            parametro.Add(new SqlParameter("@IdDepa", Clase.IdDepartamento));

            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec AgregarClase @ClaseNombre, @IdDepa", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> ActualizarClase(Clase Clase)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@IdClase", Clase.IdClase));
            parametro.Add(new SqlParameter("@ClaseNombre", Clase.Nombre));
            parametro.Add(new SqlParameter("@IdDepartamento", Clase.IdDepartamento));


            var resultado = await Task.Run(() => _db.Database
                                .ExecuteSqlRawAsync(@"exec ActualizarClase @IdClase, @ClaseNombre, @IdDepartamento", parametro.ToArray()));

            return resultado;
        }

        public async Task<int> EliminarClase(int idClase)
        {
            return await Task.Run(() => _db.Database.ExecuteSqlInterpolatedAsync($"EliminarClase {idClase}"));
        }
    }
}
