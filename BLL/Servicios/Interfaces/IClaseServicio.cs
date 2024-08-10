using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IClaseServicio
    {
        /*
        Task<IEnumerable<ClaseDTO>> ObtenerTodos();
        Task<ClaseDTO> Agregar(ClaseDTO dto);
        //Task Actualizar(ClaseDTO dto);
        Task Remover(int id);
        */
        public Task<List<ClaseDTO>> ObtenerLista();
        public Task<IEnumerable<ClaseDTO>> ObtenerClaseId(int id);
        public Task<int> AgregarClase(ClaseDTO dto);
        public Task<int> ActualizarClase(ClaseDTO dto);
        public Task<int> EliminarClase(int idClase);
    }
}
