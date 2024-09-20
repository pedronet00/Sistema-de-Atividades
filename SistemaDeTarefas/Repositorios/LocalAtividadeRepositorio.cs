using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class LocalAtividadeRepositorio : ILocalAtividadeRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public LocalAtividadeRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<LocalAtividadeModel>> buscarLocalAtividade()
        {
            return await _dbContext.LocalAtividade.ToListAsync();
        }

        public async Task<LocalAtividadeModel> inserirLocalAtividade(LocalAtividadeModel localAtividade)
        {
            await _dbContext.LocalAtividade.AddAsync(localAtividade);
            await _dbContext.SaveChangesAsync();

            return localAtividade;

        }
    }
}
