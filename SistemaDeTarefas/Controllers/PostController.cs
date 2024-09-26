using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepositorio _postRepositorio;
        public PostController(IPostRepositorio post)
        {
            _postRepositorio = post;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostModel>>> Index()
        {
            var response = new Object();

            try
            {
                List<PostModel> posts = await _postRepositorio.listarPosts();


                response = new
                {
                    message = "Sucesso!",
                    tiposAtividades = posts,
                    status = 200
                };

            }
            catch (Exception ex)
            {
                response = new
                {
                    message = "Erro ao buscar posts!",
                    erro = ex.Message,
                    status = 500
                };
            }

            return Ok(response);
        }
    }
}
