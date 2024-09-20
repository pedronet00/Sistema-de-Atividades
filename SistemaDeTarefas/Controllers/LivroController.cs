using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {

        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<LivroModel>>> Index()
        {

            var response = new Object();

            try
            {
                List<LivroModel> livros = await _livroRepositorio.buscarLivros();

               
                response = new
                {
                    message = "Sucesso!",
                    livros = livros,
                    status = 200
                };

            } catch(Exception ex)
            {
                response = new
                {
                    message = "Erro ao buscar livros!",
                    erro = ex.Message,
                    status = 500
                };
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroModel>> Show(int id)
        {

            var response = new Object();

            try
            {
                LivroModel livro = await _livroRepositorio.buscarLivro(id);

                if (livro == null)
                {
                    throw new Exception("Livro não existe!");
                }

                response = new
                {
                    message = "Livro encontrado com sucesso!",
                    livro = livro
                };
            }
            catch (Exception ex) 
            {
                response = new
                {
                    message = "Falha ao buscar livro!",
                    erro = ex.Message,
                };
            }

            return Ok(response);

        }
        
        [HttpPost]
        public async Task<ActionResult<LivroModel>> Store([FromBody] LivroModel livroModel)
        {

            var response = new Object();

            try
            {

                if (livroModel == null)
                {
                    throw new Exception("Nenhum dado foi enviado na requisição.");
                }

                // validações adicionais
                if (string.IsNullOrWhiteSpace(livroModel.nomeLivro)) 
                {
                    throw new Exception("O nome do livro é obrigatório.");
                }

                LivroModel livro = await _livroRepositorio.cadastrarLivro(livroModel);

                response = new
                {
                    message = "Sucesso!",
                    livro = livro,
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

        [HttpPatch("{id}")]
        public async Task<ActionResult<LivroModel>> Deactivate(int id)
        {
            await _livroRepositorio.desativarLivro(id);

            return Ok();
        }
    }
}
