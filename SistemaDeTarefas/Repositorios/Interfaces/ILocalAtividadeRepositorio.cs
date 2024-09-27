using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ILocalAtividadeRepositorio
    {

        Task<List<LocalAtividadeModel>> buscarLocalAtividade();

        Task<LocalAtividadeModel> inserirLocalAtividade(LocalAtividadeModel localAtividade);

        Task<LocalAtividadeModel> editarLocalAtividade(LocalAtividadeModel localAtividade, int id);
        Task<LocalAtividadeModel> desativarLocalAtividade(int id);
        Task<LocalAtividadeModel> ativarLocalAtividade(int id);
    }
}
