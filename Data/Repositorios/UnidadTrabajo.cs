using Data.Interfaces;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly AppDBContext _db;
        public IClaseRepositorio Clase { get; private set; }
        public IDepartamentoRepositorio Departamento { get; private set; }
        public IFamiliaRepositorio Familia { get; private set; }
        public IArticuloRepositorio Articulo { get; private set; }

        public UnidadTrabajo(AppDBContext db)
        {
            _db = db;
            Clase = new ClaseRepositorio(db);
            Departamento = new DepartamentoRepositorio(db);
            Familia = new FamiliaRepositorio(db);
            Articulo = new ArticuloRepositorio(db);

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
