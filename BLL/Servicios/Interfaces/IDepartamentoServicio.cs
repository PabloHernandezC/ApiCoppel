using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IDepartamentoServicio
    {
        Task<IEnumerable<Departamento>> ObtenerTodos();
        Task<Departamento> Agregar(Departamento dto);
        Task Actualizar(Departamento dto);
        Task Remover(int id);
    }
}
