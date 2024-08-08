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
        Task<IEnumerable<Familia>> ObtenerTodos();
        Task<Familia> Agregar(Familia dto);
        Task Actualizar(Familia dto);
        Task Remover(int id);
    }
}
