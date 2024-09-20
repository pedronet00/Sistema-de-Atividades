using SistemaDeTarefas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IAtividadeRepositorio
    {
        Task<IEnumerable<AtividadeModel>> GetAllAtividades();
        Task<AtividadeModel> GetAtividadeById(string id);
        Task<AtividadeModel> CreateAtividade(AtividadeModel atividade);
        Task<AtividadeModel> UpdateAtividade(AtividadeModel atividade);
        Task<bool> DeleteAtividade(string id);
    }
}
