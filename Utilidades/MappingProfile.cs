using AutoMapper;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*
            CreateMap<Articulo, ArticuloDTO>()
                .ForMember(d => d.Descontinuado, m => m.MapFrom(o => o.Descontinuado == true ? 1 : 0))
                .ForMember(d => d.NombreClase, m => m.MapFrom(o => o.clase.Nombre))
                .ForMember(d => d.NombreDepartamento, m => m.MapFrom(o => o.departamento.Nombre))
                .ForMember(d => d.NombreFamilia, m => m.MapFrom(o => o.familia.Nombre));

            CreateMap<Clase, ClaseDTO>()
                .ForMember(d => d.NombreDepartamento, m => m.MapFrom(o => o.departamento.Nombre));
            */
        }
    }
}
