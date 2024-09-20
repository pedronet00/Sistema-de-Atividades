using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext SistemaTarefasDBContext) 
        {
            _dbContext = SistemaTarefasDBContext;
        }


        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("O usuário não existe!");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioPorId(id);

            if (usuarioPorId == null) 
            {
                throw new Exception("O usuário não existe!");
            }

            usuarioPorId.name = usuario.name;
            usuarioPorId.email = usuario.email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
           return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
