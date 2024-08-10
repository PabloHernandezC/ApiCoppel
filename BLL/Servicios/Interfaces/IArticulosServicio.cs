using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IArticulosServicio
    {
        /*
        Task<IEnumerable<ArticuloDTO>> ObtenerTodos();
        Task<ArticuloDTO> Agregar(ArticuloDTO dto);
        Task Actualizar(ArticuloDTO dto);
        Task Remover(int Sku);
        Task<bool> ExisteSku(int Sku);
        */

        public Task<List<ArticuloDTO>> ObtenerLista();
        public Task<IEnumerable<ArticuloDTO>> ObtenerSKU(int id);
        public Task<int> AgregarArticulo(ArticuloDTO dto);
        public Task<int> Actualizar(ArticuloDTO dto);
        public Task<int> Eliminar(int id);
        public Task<bool> ExisteSku(int id);
    }
}
