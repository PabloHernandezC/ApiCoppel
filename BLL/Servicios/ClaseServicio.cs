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
    public class ClaseServicio : IClaseServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ClaseServicio(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task Actualizar(Clase dto)
        {
            try
            {
                var claseDb = await _unidadTrabajo.Clase.ObtenerPrimero(e => e.IdClase == dto.IdClase);
                if (claseDb == null)
                    throw new TaskCanceledException("La Clase no Existe");
                claseDb = await _unidadTrabajo.Clase.ObtenerPrimero(e => e.Nombre.ToLower() == dto.Nombre.ToLower());
                if (claseDb != null)
                    throw new TaskCanceledException("El nombre de la Clase ya Existe");

                _unidadTrabajo.Clase.Actualizar(dto);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Clase> Agregar(Clase dto)
        {
            try {
                var claseDb = await _unidadTrabajo.Clase.ObtenerPrimero(e => e.Nombre.ToLower() == dto.Nombre.ToLower());
                if (claseDb != null)
                    throw new TaskCanceledException("El nombre de la Clase ya Existe");

                await _unidadTrabajo.Clase.Agregar(dto);
                await _unidadTrabajo.Guardar();

                if (dto.IdClase == 0) 
                    throw new TaskCanceledException("La Clase no se pudo Crear");

                return dto;
            }
            catch (Exception){ 
                throw;
            }
        }

        public async Task<IEnumerable<Clase>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Clase.ObtenerTodos(
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
                var claseDb = await _unidadTrabajo.Clase.ObtenerPrimero(e => e.IdClase == id);
                if (claseDb == null)
                    throw new TaskCanceledException("La Clase no Existe");

                _unidadTrabajo.Clase.Remover(claseDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
