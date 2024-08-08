using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IArticulosService
    {
        Task<IEnumerable<ArticuloDTO>> ObtenerTodos();
        Task<ArticuloDTO> Agregar(ArticuloDTO dto);
        Task Actualizar(ArticuloDTO dto);
        Task Remover(int Sku);
        Task<bool> ExisteSku(int Sku);
    }
}
