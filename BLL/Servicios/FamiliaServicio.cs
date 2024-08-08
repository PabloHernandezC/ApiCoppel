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
    public class FamiliaServicio : IFamiliaServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public FamiliaServicio(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task Actualizar(Familia dto)
        {
            try
            {
                var familiaDb = await _unidadTrabajo.Familia.ObtenerPrimero(e => e.IdFamilia == dto.IdFamilia);
                if (familiaDb == null)
                    throw new TaskCanceledException("La Familia no Existe");
                familiaDb = await _unidadTrabajo.Familia.ObtenerPrimero(e => e.Nombre.ToLower() == dto.Nombre.ToLower());
                if (familiaDb != null)
                    throw new TaskCanceledException("El nombre de la Familia ya Existe");

                _unidadTrabajo.Familia.Actualizar(dto);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Familia> Agregar(Familia dto)
        {
            try
            {
                var familiaDb = await _unidadTrabajo.Familia.ObtenerPrimero(e => e.Nombre.ToLower() == dto.Nombre.ToLower());
                if (familiaDb != null)
                    throw new TaskCanceledException("El nombre de la Familia ya Existe");

                await _unidadTrabajo.Familia.Agregar(dto);
                await _unidadTrabajo.Guardar();

                if (dto.IdFamilia == 0)
                    throw new TaskCanceledException("La Familia no se pudo Crear");

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Familia>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Familia.ObtenerTodos(
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
                var familiaDb = await _unidadTrabajo.Familia.ObtenerPrimero(e => e.IdFamilia == id);
                if (familiaDb == null)
                    throw new TaskCanceledException("La Familia no Existe");

                _unidadTrabajo.Familia.Remover(familiaDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
