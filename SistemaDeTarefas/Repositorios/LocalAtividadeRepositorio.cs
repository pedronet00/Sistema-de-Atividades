using Microsoft.AspNetCore.Http.HttpResults;
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


        public async Task<LocalAtividadeModel> desativarLocalAtividade(int id)
        {
            LocalAtividadeModel localAtividade = await _dbContext.LocalAtividade.FirstOrDefaultAsync(x => x.Id == id);
            localAtividade.statusLocalAtividade = 0;
            await _dbContext.SaveChangesAsync();

            return localAtividade;
        }

        public async Task<LocalAtividadeModel> ativarLocalAtividade(int id)
        {
            LocalAtividadeModel localAtividade = await _dbContext.LocalAtividade.FirstOrDefaultAsync(x => x.Id == id);
            localAtividade.statusLocalAtividade = 1;
            await _dbContext.SaveChangesAsync();

            return localAtividade;
        }

        async Task<LocalAtividadeModel> ILocalAtividadeRepositorio.editarLocalAtividade(LocalAtividadeModel localAtividadeModel, int id)
        {
            LocalAtividadeModel localAtividade = await _dbContext.LocalAtividade.FirstOrDefaultAsync(x => x.Id == id);

            if (localAtividade == null)
            {
                throw new Exception("Local não encontrado.");
            }

            localAtividade.localAtividade = localAtividadeModel.localAtividade;

            _dbContext.LocalAtividade.Update(localAtividade);
            await _dbContext.SaveChangesAsync();

            return localAtividade;
        }

    }
}
