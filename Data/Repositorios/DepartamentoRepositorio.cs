using Data.Interfaces;
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

        public void Actualizar(Departamento departamento)
        {
            var departamentoDB = _db.Departamentos.FirstOrDefault(e => e.IdDepartamento == departamento.IdDepartamento);
            if (departamentoDB != null)
            {
                departamentoDB.Nombre = departamento.Nombre;
                _db.SaveChanges();
            }
        }
    }
}
