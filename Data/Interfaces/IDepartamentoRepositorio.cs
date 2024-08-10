using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDepartamentoRepositorio : IRepositorioGenerico<Departamento>
    {

        public Task<List<Departamento>> ObtenerLista();
        public Task<IEnumerable<Departamento>> ObtenerDepartamentoId(int id);
        public Task<int> AgregarDepartamento(Departamento departamento);
        public Task<int> ActualizarDepartamento(Departamento departamento);
        public Task<int> EliminarDepartemento(int idDepartamento);
    }
}
