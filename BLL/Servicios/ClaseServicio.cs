using AutoMapper;
using BLL.Servicios.Interfaces;
using Data.Interfaces;
using Models.DTOs;
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
        private readonly IMapper _mapper;

        public ClaseServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Task<int> ActualizarClase(ClaseDTO dto)
        {
            Clase clase = new Clase
            {
                IdClase = dto.IdClase,
                Nombre = dto.NombreClase,
                IdDepartamento = dto.IdDepartamento,
            };

            return _unidadTrabajo.Clase.ActualizarClase(clase);
        }

        public Task<int> AgregarClase(ClaseDTO dto)
        {
            Clase clase = new Clase
            {
                Nombre = dto.NombreClase,
                IdDepartamento = dto.IdDepartamento,
            };

            return _unidadTrabajo.Clase.AgregarClase(clase);
        }

        public Task<int> EliminarClase(int idClase)
        {
            return _unidadTrabajo.Clase.EliminarClase(idClase);
        }

        public Task<IEnumerable<ClaseDTO>> ObtenerClaseId(int id)
        {
            return _unidadTrabajo.Clase.ObtenerClaseId(id);
        }

        public Task<List<ClaseDTO>> ObtenerLista()
        {
            return _unidadTrabajo.Clase.ObtenerLista();
        }
    }
}
