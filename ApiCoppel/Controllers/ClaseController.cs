using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entidades;
using System.Net;
using WebCoppel.Controllers;

namespace ApiCoppel.Controllers
{
    public class ClaseController : BaseAPIController
    {
        private readonly IClaseServicio _claseServicio;
        private ApiResponse _response;
        private string mensajeExitoso = "Peticion Exitosa";

        public ClaseController(IClaseServicio claseServicio)
        {
            _claseServicio = claseServicio;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _claseServicio.ObtenerTodos();
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
        public async Task<IActionResult> Crear(Clase dto)
        {
            try
            {
                await _claseServicio.Agregar(dto);
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
        public async Task<IActionResult> Editar(Clase dto)
        {
            try
            {
                await _claseServicio.Actualizar(dto);
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
                await _claseServicio.Remover(id);
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
