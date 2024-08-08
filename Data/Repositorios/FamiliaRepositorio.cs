using Data.Interfaces;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Actualizar(Familia familia)
        {
            var familiaDB = _db.Familias.FirstOrDefault(e => e.IdFamilia == familia.IdFamilia);
            if (familiaDB != null)
            {
                familiaDB.Nombre = familia.Nombre;
                _db.SaveChanges();
            }
        }
    }
}
