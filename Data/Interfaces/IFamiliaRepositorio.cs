using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFamiliaRepositorio : IRepositorioGenerico<Familia>
    {
        //void Actualizar(Familia familia);

        public Task<List<FamiliaDTO>> ObtenerLista();
        public Task<IEnumerable<FamiliaDTO>> ObtenerFamiliaId(int id);
        public Task<int> AgregarFamilia(Familia familia);
        public Task<int> ActualizarFamilia(Familia familia);
        public Task<int> EliminarFamilia(int idFamilia);
    }
}
