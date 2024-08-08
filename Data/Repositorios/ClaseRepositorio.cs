using Data.Interfaces;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Actualizar(Clase clase)
        {
            var claseDB = _db.Clases.FirstOrDefault(e => e.IdClase == clase.IdClase);
            if (claseDB != null)
            {
                claseDB.Nombre = clase.Nombre;
                _db.SaveChanges();
            }
        }
    }
}
