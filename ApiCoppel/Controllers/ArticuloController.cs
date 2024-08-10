using BLL.Servicios;
using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using System.Net;
using WebCoppel.Controllers;

namespace ApiCoppel.Controllers
{
    public class ArticuloController : BaseAPIController
    {
        private readonly IArticulosServicio _articuloServicio;
        private ApiResponse _response;
        private string mensajeExitoso = "Peticion Exitosa";

        public ArticuloController(IArticulosServicio articulo)
        {
            _articuloServicio = articulo;
            _response = new();
        }
        /*
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _articuloServicio.ObtenerTodos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ArticuloDTO dto)
        {
            try
            {
                await _articuloServicio.Agregar(dto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(ArticuloDTO dto)
        {
            try
            {
                await _articuloServicio.Actualizar(dto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _articuloServicio.Remover(id);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }
            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ExisteSku(int id)
        {
            try
            {
                _response.Resultado = await _articuloServicio.ExisteSku(id);
                _response.IsExitoso= true;
                _response.StatusCode=HttpStatusCode.NoContent;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }
            
            return Ok(_response);
        }*/

        [HttpGet("ObtenerLista")]
        public async Task<IActionResult> ObtenerLista()
        {
            try
            {
                _response.Resultado = await _articuloServicio.ObtenerLista();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }

            return Ok(_response);
        }

        [HttpGet("ObtenerSku/{id:int}")]
        public async Task<IActionResult> ObtenerSku(int id)
        {
            try
            {
                var respuesta = await _articuloServicio.ObtenerSKU(id);
                _response.Resultado = respuesta;
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }

            return Ok(_response);
        }

        [HttpGet("ExisteSku/{id:int}")]
        public async Task<IActionResult> ExisteSku(int id)
        {
            try
            {
                var respuesta = await _articuloServicio.ExisteSku(id);
                _response.Resultado = respuesta;
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }

            return Ok(_response);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar(ArticuloDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                var respuesta = await _articuloServicio.AgregarArticulo(dto);

                _response.Resultado = respuesta;
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }

            return Ok(_response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> EditarSP(ArticuloDTO dto)
        {
            try
            {
                var respuesta = await _articuloServicio.Actualizar(dto);

                _response.Resultado = respuesta;
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }

            return Ok(_response);
        }

        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> EliminarSP(int id)
        {
            try
            {
                var respuesta = await _articuloServicio.Eliminar(id);

                _response.Resultado = respuesta;
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Mensaje = mensajeExitoso;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Mensaje = ex.Message;
                throw;
            }
            return Ok(_response);
        }
    }
}
