using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IFamiliaServicio
    {
        /*
        Task<IEnumerable<Familia>> ObtenerTodos();
        Task<Familia> Agregar(Familia dto);
        Task Actualizar(Familia dto);
        Task Remover(int id);*/

        public Task<List<FamiliaDTO>> ObtenerLista();
        public Task<IEnumerable<FamiliaDTO>> ObtenerFamiliaId(int id);
        public Task<int> AgregarFamilia(FamiliaDTO dto);
        public Task<int> ActualizarFamilia(FamiliaDTO dto);
        public Task<int> EliminarFamilia(int idFamilia);
    }
}
