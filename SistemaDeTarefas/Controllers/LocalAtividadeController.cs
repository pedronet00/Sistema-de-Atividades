using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalAtividadeController : ControllerBase
    {

        private readonly ILocalAtividadeRepositorio _localAtividadeRepositorio;
        public LocalAtividadeController(ILocalAtividadeRepositorio localAtividade)
        {
            _localAtividadeRepositorio = localAtividade;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocalAtividadeModel>>> Index()
        {
            var response = new Object();

            try
            {
                List<LocalAtividadeModel> localAtividades = await _localAtividadeRepositorio.buscarLocalAtividade();


                response = new
                {
                    message = "Sucesso!",
                    tiposAtividades = localAtividades,
                    status = 200
                };

            }
            catch (Exception ex)
            {
                response = new
                {
                    message = "Erro ao buscar locais de atividades!",
                    erro = ex.Message,
                    status = 500
                };
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<LocalAtividadeModel>> Store([FromBody] LocalAtividadeModel localAtividadesModel)
        {

            var response = new Object();

            try
            {

                if (localAtividadesModel == null)
                {
                    throw new Exception("Nenhum dado foi enviado na requisição.");
                }

                // validações adicionais
                if (string.IsNullOrWhiteSpace(localAtividadesModel.localAtividade))
                {
                    throw new Exception("O local da atividade é obrigatório.");
                }

                LocalAtividadeModel localAtividade = await _localAtividadeRepositorio.inserirLocalAtividade(localAtividadesModel);

                response = new
                {
                    message = "Sucesso!",
                    tipoAtividade = localAtividade,
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