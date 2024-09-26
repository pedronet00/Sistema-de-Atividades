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
                    posts = posts,
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

        [HttpPost]
        public async Task<ActionResult<PostModel>> Store([FromBody] PostModel postModel)
        {

            var response = new Object();

            try
            {

                if (postModel == null)
                {
                    throw new Exception("Nenhum dado foi enviado na requisição.");
                }

                // validações adicionais
                if (string.IsNullOrWhiteSpace(postModel.tituloPost))
                {
                    throw new Exception("O título do post é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(postModel.descricaoPost))
                {
                    throw new Exception("A descrição do post é obrigatória.");
                }

                if (string.IsNullOrWhiteSpace(postModel.textoPost))
                {
                    throw new Exception("O texto do post é obrigatório.");
                }

                PostModel post = await _postRepositorio.inserirPost(postModel);

                response = new
                {
                    message = "Sucesso!",
                    post = post,
                    status = 200
                };
            }
            catch (Exception ex)
            {
                response = new
                {
                    message = "Erro!",
                    error = ex.Message,
                    status = 500
                };
            }

            return Ok(response);




        }
    }
}
