using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Migrations;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeRepositorio _atividadeRepositorio;

        public AtividadeController(IAtividadeRepositorio atividadeRepositorio)
        {
            _atividadeRepositorio = atividadeRepositorio;
        }

        // GET: api/Atividade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtividadeModel>>> GetAllAtividades()
        {

            var response = new Object();

            try
            {
                var atividades = await _atividadeRepositorio.GetAllAtividades();

                response = new
                {
                    message = "Sucesso!",
                    tiposAtividades = atividades,
                    status = 200
                };
            }
            catch (Exception ex) 
            {
                response = new
                {
                    message = "Erro ao buscar atividades!",
                    erro = ex.Message,
                    status = 500
                };
            }


            return Ok(response);
        }

        // GET: api/Atividade/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AtividadeModel>> GetAtividadeById(string id)
        {
            var atividade = await _atividadeRepositorio.GetAtividadeById(id);
            if (atividade == null)
            {
                return NotFound();
            }
            return Ok(atividade);
        }

        // POST: api/Atividade
        [HttpPost]
        public async Task<ActionResult<AtividadeModel>> CreateAtividade(AtividadeModel atividade)
        {
            var novaAtividade = await _atividadeRepositorio.CreateAtividade(atividade);
            return CreatedAtAction(nameof(GetAtividadeById), new { id = novaAtividade.Id }, novaAtividade);
        }

        // PUT: api/Atividade/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAtividade(string id, AtividadeModel atividade)
        {
            if (id != atividade.Id)
            {
                return BadRequest("ID da atividade não corresponde à uma atividade.");
            }

            await _atividadeRepositorio.UpdateAtividade(atividade);
            return NoContent();
        }

        // DELETE: api/Atividade/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAtividade(string id)
        {
            var resultado = await _atividadeRepositorio.DeleteAtividade(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
