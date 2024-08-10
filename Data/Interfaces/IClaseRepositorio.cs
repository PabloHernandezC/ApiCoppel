using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IClaseRepositorio : IRepositorioGenerico<Clase>
    {
        public Task<List<ClaseDTO>> ObtenerLista();
        public Task<IEnumerable<ClaseDTO>> ObtenerClaseId(int id);
        public Task<int> AgregarClase(Clase Clase);
        public Task<int> ActualizarClase(Clase Clase);
        public Task<int> EliminarClase(int idClase);
    }
}
