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
        Task<IEnumerable<Clase>> ObtenerTodos();
        Task<Clase> Agregar(Clase dto);
        Task Actualizar(Clase dto);
        Task Remover(int id);
    }
}
