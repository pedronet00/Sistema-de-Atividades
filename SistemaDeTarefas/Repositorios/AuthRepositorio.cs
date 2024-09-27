using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class AuthRepositorio : IAuthRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public AuthRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        async public Task<UsuarioModel> login(string email, string password)
        {
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.email == email && u.password == password);

            if (usuario == null)
            {

                throw new Exception("Email ou senha inválidos.");
            }

            // Retorne o usuário autenticado
            return usuario;
        }

        async public Task<UsuarioModel> logout()
        {
            return await Task.FromResult<UsuarioModel>(null);
        }
    }
}
