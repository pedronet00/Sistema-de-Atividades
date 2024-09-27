using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IAuthRepositorio
    {

        Task<UsuarioModel> login(string username, string password);

        Task<UsuarioModel> logout();
    }
}
