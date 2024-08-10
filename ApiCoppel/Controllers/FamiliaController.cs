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

    public class FamiliaController : BaseAPIController
    {
        private readonly IFamiliaServicio _familiaServicio;
        private ApiResponse _response;
        private string mensajeExitoso = "Peticion Exitosa";

        public FamiliaController(IFamiliaServicio familiaServicio)
        {
            _familiaServicio = familiaServicio;
            _response = new();
        }

        [HttpGet("ObtenerLista")]
        public async Task<IActionResult> ObtenerLista()
        {
            try
            {
                _response.Resultado = await _familiaServicio.ObtenerLista();
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
                var respuesta = await _familiaServicio.ObtenerFamiliaId(id);
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
        public async Task<IActionResult> Agregar(FamiliaDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                var respuesta = await _familiaServicio.AgregarFamilia(dto);

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
        public async Task<IActionResult> EditarSP(FamiliaDTO dto)
        {
            try
            {
                var respuesta = await _familiaServicio.ActualizarFamilia(dto);

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
                var respuesta = await _familiaServicio.EliminarFamilia(id);

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
