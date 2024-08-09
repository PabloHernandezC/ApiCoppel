using BLL.Servicios.Interfaces;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace WebCoppel.Controllers
{
    public class UsuarioController : BaseAPIController
    {
        private readonly AppDBContext _dbContext;
        private readonly ITokenServicio _tokenServicio;

        public UsuarioController(AppDBContext dbContext, ITokenServicio tokenServicio)
        {
            _dbContext = dbContext;
            _tokenServicio = tokenServicio;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            return Ok(usuario);
        }

        [HttpPost("registro")]
        public async Task<ActionResult<UsuarioDTO>> Registro(RegistroDTO registroDTO)
        {
            if (await UsuarioExiste(registroDTO.userName))
                return BadRequest("El usuario ya existe");

            using var hmac = new HMACSHA512();
            var usuario = new Usuario
            {
                userName = registroDTO.userName,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registroDTO.password)),
                passwordSalt = hmac.Key
            };

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return new UsuarioDTO
            {
                userName = usuario.userName,
                token = _tokenServicio.CrearToken(usuario)
            };
        }

        private async Task<bool> UsuarioExiste(string userName)
        {
            return await _dbContext.Usuarios.AnyAsync(usuario => usuario.userName == userName.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> login(LoginDTO login)
        {
            var usuario = await _dbContext.Usuarios.SingleOrDefaultAsync(x => x.userName == login.UserName);
            if (usuario == null) return Unauthorized("El usuario no existe");
            using var hmac = new HMACSHA512(usuario.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.passwordHash[i]) return Unauthorized("Password no valido");
            }

            return new UsuarioDTO
            {
                userName = usuario.userName,
                token = _tokenServicio.CrearToken(usuario)
            };

        }

    }
}
