using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ILivroRepositorio
    {

        Task<List<LivroModel>> buscarLivros();

        Task<LivroModel> cadastrarLivro(LivroModel livro);

        Task<LivroModel> buscarLivro(int id);

        Task<LivroModel> desativarLivro(int id);


    }
}
