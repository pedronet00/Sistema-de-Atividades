using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        // CONSTRUTOR
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        // LISTANDO TODOS OS USUÁRIOS
        [HttpGet]
        public async Task <ActionResult<List<UsuarioModel>>> Index() 
        {
            List<UsuarioModel> usuarios =  await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        // LISTANDO UM USUÁRIO
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> Show(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioPorId(id);
            return Ok(usuario);
        }


        // INSERINDO UM USUÁRIO
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Store([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);

            var response = new
            {
                status = 201,
                message = "Usuário cadastrado com sucesso!",
                usuario = usuario
            };

            return Ok(response);
        }


        // ALTERANDO UM USUÁRIO
        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);

            return Ok(usuario);
        }


        // EXCLUINDO UM USUÁRIO
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
