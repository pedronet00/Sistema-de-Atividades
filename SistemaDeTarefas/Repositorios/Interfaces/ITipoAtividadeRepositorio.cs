using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITipoAtividadeRepositorio
    {
        Task<List<TipoAtividadeModel>> buscarTipoAtividade();

        Task<TipoAtividadeModel> cadastrarTipoAtividade(TipoAtividadeModel tipoAtividade);

        Task<TipoAtividadeModel> desativarTipoAtividade(int id);

    }
}
