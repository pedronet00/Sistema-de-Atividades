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
        public async Task<IActionResult> Login([FromBody] AuthModel authModel)
        {
            if (authModel == null || string.IsNullOrEmpty(authModel.email) || string.IsNullOrEmpty(authModel.password))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            var usuario = await _authRepositorio.login(authModel.email, authModel.password);

            if (usuario == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            // Aqui você pode gerar e retornar um token de autenticação, se necessário.
            return Ok(usuario);
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authRepositorio.logout();
            return Ok("Logout realizado com sucesso.");
        }
    }
}
