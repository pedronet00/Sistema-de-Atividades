using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepositorio _authRepositorio;

        public AuthController(IAuthRepositorio authRepositorio)
        {
            _authRepositorio = authRepositorio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel == null || string.IsNullOrEmpty(usuarioModel.email) || string.IsNullOrEmpty(usuarioModel.password))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            var usuario = await _authRepositorio.login(usuarioModel.email, usuarioModel.password);

            if (usuario == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            // Aqui você pode gerar e retornar um token de autenticação, se necessário.
            return Ok(usuario);
        }

    }
}
