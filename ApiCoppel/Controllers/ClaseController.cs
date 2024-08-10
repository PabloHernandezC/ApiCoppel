using BLL.Servicios;
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

        [HttpGet("ObtenerLista")]
        public async Task<IActionResult> ObtenerLista()
        {
            try
            {
                _response.Resultado = await _claseServicio.ObtenerLista();
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

        [HttpGet("ObtenerId/{id:int}")]
        public async Task<IActionResult> ObtenerId(int id)
        {
            try
            {
                var respuesta = await _claseServicio.ObtenerClaseId(id);
                if (respuesta == null)
                {
                    return null;
                }
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
        public async Task<IActionResult> Agregar(ClaseDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                var respuesta = await _claseServicio.AgregarClase(dto);

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
        public async Task<IActionResult> EditarSP(ClaseDTO dto)
        {
            try
            {
                var respuesta = await _claseServicio.ActualizarClase(dto);

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
                var respuesta = await _claseServicio.EliminarClase(id);

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
