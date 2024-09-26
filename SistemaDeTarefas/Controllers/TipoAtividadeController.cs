using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAtividadeController : ControllerBase
    {

        private readonly ITipoAtividadeRepositorio _tipoAtividadeRepositorio;
        public TipoAtividadeController(ITipoAtividadeRepositorio tipoAtividade)
        {
            _tipoAtividadeRepositorio = tipoAtividade;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoAtividadeModel>>> Index()
        {
            var response = new Object();

            try
            {
                List<TipoAtividadeModel> tipoAtividades = await _tipoAtividadeRepositorio.buscarTipoAtividade();


                response = new
                {
                    message = "Sucesso!",
                    tiposAtividades = tipoAtividades,
                    status = 200
                };

            }
            catch (Exception ex)
            {
                response = new
                {
                    message = "Erro ao buscar tipos de atividades!",
                    erro = ex.Message,
                    status = 500
                };
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TipoAtividadeModel>> Store([FromBody] TipoAtividadeModel tipoAtividadeModel)
        {

            var response = new Object();

            try
            {

                if (tipoAtividadeModel == null)
                {
                    throw new Exception("Nenhum dado foi enviado na requisição.");
                }

                // validações adicionais
                if (string.IsNullOrWhiteSpace(tipoAtividadeModel.tipoAtividade))
                {
                    throw new Exception("O tipo de atividade é obrigatório.");
                }

                TipoAtividadeModel tipoAtividade = await _tipoAtividadeRepositorio.cadastrarTipoAtividade(tipoAtividadeModel);

                response = new
                {
                    message = "Sucesso!",
                    tipoAtividade = tipoAtividade,
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
        public async Task<ActionResult<TipoAtividadeModel>> desativarTipoAtividade(int id)
        {
            await _tipoAtividadeRepositorio.desativarTipoAtividade(id);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TipoAtividadeModel>> ativarTipoAtividade(int id)
        {
            await _tipoAtividadeRepositorio.ativarTipoAtividade(id);

            return Ok();
        }
    }
}