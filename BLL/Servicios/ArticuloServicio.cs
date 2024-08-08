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
    public class ArticuloServicio : IArticulosService
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public ArticuloServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task Actualizar(ArticuloDTO dto)
        {
            try
            {
                var articuloDb = await _unidadTrabajo.Articulo.ObtenerPrimero(e => e.Sku == dto.Sku);
                if (articuloDb == null)
                    throw new TaskCanceledException("El Articulo no Existe");

                articuloDb.Article = dto.Article;
                articuloDb.Marca = dto.Marca;
                articuloDb.Modelo = dto.Modelo;
                articuloDb.IdClase = dto.IdClase;
                articuloDb.IdDepartamento = dto.IdDepartamento;
                articuloDb.IdFamilia = dto.IdFamilia;
                articuloDb.Cantidad = dto.Cantidad;
                articuloDb.Stock = dto.Stock;
                articuloDb.Descontinuado = dto.Descontinuado == 1 ? true : false ;

                _unidadTrabajo.Articulo.Actualizar(articuloDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ArticuloDTO> Agregar(ArticuloDTO dto)
        {
            Articulo articulo = new Articulo 
            {
                Sku = dto.Sku,
                Article = dto.Article,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                IdClase = dto.IdClase,  
                IdDepartamento= dto.IdDepartamento,
                IdFamilia = dto.IdFamilia,
                FechaAlta = DateTime.Now,
                Stock = dto.Stock,
                Cantidad = dto.Cantidad,
                Descontinuado = dto.Descontinuado == 1 ? true : false,
                FechaBaja = new DateTime(1900, 1, 1)
            };

            await _unidadTrabajo.Articulo.Agregar(articulo);
            await _unidadTrabajo.Guardar();

            if(articulo.Sku == 0)
                throw new TaskCanceledException("El articulo no se pudo Crear");

            return _mapper.Map<ArticuloDTO>(articulo);
        }

        public async Task<bool> ExisteSku(int Sku)
        {
            var articuloDb = await _unidadTrabajo.Articulo.ObtenerPrimero(e => e.Sku == Sku);
            return articuloDb != null;
        }

        public async Task<IEnumerable<ArticuloDTO>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Articulo.ObtenerTodos(
                    orderBy: e => e.OrderBy(e => e.Article));

                return _mapper.Map<IEnumerable<ArticuloDTO>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int Sku)
        {
            try
            {
                var articuloDb = await _unidadTrabajo.Articulo.ObtenerPrimero(e => e.Sku == Sku);
                if (articuloDb == null)
                    throw new TaskCanceledException("El Articulo no Existe");

                _unidadTrabajo.Articulo.Remover(articuloDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
