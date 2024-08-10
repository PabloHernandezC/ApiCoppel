using BLL.Servicios.Interfaces;
using Data.Interfaces;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class DepartamentoServicio : IDepartamentoServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public DepartamentoServicio(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<int> ActualizarDepartamento(Departamento departamento)
        {
            return await _unidadTrabajo.Departamento.ActualizarDepartamento(departamento);
        }

        public async Task<int> AgregarDepartamento(Departamento departamento)
        {
            return await _unidadTrabajo.Departamento.AgregarDepartamento(departamento);
        }

        public async Task<int> EliminarDepartemento(int idDepartamento)
        {
            return await _unidadTrabajo.Departamento.EliminarDepartemento(idDepartamento);
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamentoId(int id)
        {
            return await _unidadTrabajo.Departamento.ObtenerDepartamentoId(id);
        }

        public async Task<List<Departamento>> ObtenerLista()
        {
            return await _unidadTrabajo.Departamento.ObtenerLista();
        }
    }
}
