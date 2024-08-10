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
    public class FamiliaServicio : IFamiliaServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public FamiliaServicio(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public Task<int> ActualizarFamilia(FamiliaDTO dto)
        {
            Familia familia = new Familia
            {
                IdFamilia = dto.idFamilia,
                Nombre = dto.NombreFamilia,
                IdClase = dto.IdClase
            };

            return _unidadTrabajo.Familia.ActualizarFamilia(familia);
        }

        public Task<int> AgregarFamilia(FamiliaDTO dto)
        {
            Familia familia = new Familia
            {
                Nombre = dto.NombreFamilia,
                IdClase = dto.IdClase
            };

            return _unidadTrabajo.Familia.AgregarFamilia(familia);
        }

        public Task<int> EliminarFamilia(int idFamilia)
        {
            return _unidadTrabajo.Familia.EliminarFamilia(idFamilia);
        }

        public Task<IEnumerable<FamiliaDTO>> ObtenerFamiliaId(int id)
        {
            return _unidadTrabajo.Familia.ObtenerFamiliaId(id);
        }

        public Task<List<FamiliaDTO>> ObtenerLista()
        {
            return _unidadTrabajo.Familia.ObtenerLista();
        }
    }
}
