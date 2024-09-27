using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITipoAtividadeRepositorio
    {
        Task<List<TipoAtividadeModel>> buscarTipoAtividade();
        Task<TipoAtividadeModel> buscarUmTipoAtividade(int id);

        Task<TipoAtividadeModel> cadastrarTipoAtividade(TipoAtividadeModel tipoAtividade);

        Task<TipoAtividadeModel> editarTipoAtividade(TipoAtividadeModel tipoAtividade, int id);

        Task<TipoAtividadeModel> desativarTipoAtividade(int id);
        Task<TipoAtividadeModel> ativarTipoAtividade(int id);

    }
}
