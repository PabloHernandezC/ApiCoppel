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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _familiaServicio.ObtenerTodos();
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
        public async Task<IActionResult> Crear(Familia dto)
        {
            try
            {
                await _familiaServicio.Agregar(dto);
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
        public async Task<IActionResult> Editar(Familia dto)
        {
            try
            {
                await _familiaServicio.Actualizar(dto);
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
                await _familiaServicio.Remover(id);
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
