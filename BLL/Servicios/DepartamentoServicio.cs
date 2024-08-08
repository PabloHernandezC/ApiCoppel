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

        public async Task Actualizar(Departamento dto)
        {
            try
            {
                var departamentoDb = await _unidadTrabajo.Departamento.ObtenerPrimero(e => e.IdDepartamento == dto.IdDepartamento);
                if (departamentoDb == null)
                    throw new TaskCanceledException("La Departamento no Existe");

                departamentoDb = await _unidadTrabajo.Departamento.ObtenerPrimero(e => e.Nombre.ToLower() == dto.Nombre.ToLower());
                if (departamentoDb != null)
                    throw new TaskCanceledException("El nombre del Departamento ya existe");

                _unidadTrabajo.Departamento.Actualizar(dto);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Departamento> Agregar(Departamento dto)
        {
            try
            {
                var departamentoDb = await _unidadTrabajo.Departamento.ObtenerPrimero(e => e.Nombre.ToLower() == dto.Nombre.ToLower());
                if (departamentoDb != null)
                    throw new TaskCanceledException("El nombre del Departamento ya existe");

                await _unidadTrabajo.Departamento.Agregar(dto);
                await _unidadTrabajo.Guardar();

                if (dto.IdDepartamento == 0)
                    throw new TaskCanceledException("El Departamento no se pudo Crear");

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Departamento>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Departamento.ObtenerTodos(
                    orderBy: e => e.OrderBy(e => e.Nombre));

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var departamentoDb = await _unidadTrabajo.Departamento.ObtenerPrimero(e => e.IdDepartamento == id);
                if (departamentoDb == null)
                    throw new TaskCanceledException("El Departamento no Existe");

                _unidadTrabajo.Departamento.Remover(departamentoDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
