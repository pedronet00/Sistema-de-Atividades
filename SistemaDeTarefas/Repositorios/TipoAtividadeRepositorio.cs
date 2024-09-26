using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TipoAtividadeRepositorio : ITipoAtividadeRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public TipoAtividadeRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoAtividadeModel>> buscarTipoAtividade()
        {
            return await _dbContext.TipoAtividade.ToListAsync();
        }

        public async Task<TipoAtividadeModel> cadastrarTipoAtividade(TipoAtividadeModel tipoAtividade)
        {
            await _dbContext.TipoAtividade.AddAsync(tipoAtividade);
            await _dbContext.SaveChangesAsync();

            return tipoAtividade;
        }

        public async Task<TipoAtividadeModel> desativarTipoAtividade(int id)
        {
            TipoAtividadeModel tipoAtividade = await _dbContext.TipoAtividade.FirstOrDefaultAsync(x => x.Id == id);
            tipoAtividade.statusTipoAtividade = 0;
            await _dbContext.SaveChangesAsync();

            return tipoAtividade;
        }

        public async Task<TipoAtividadeModel> ativarTipoAtividade(int id)
        {
            TipoAtividadeModel tipoAtividade = await _dbContext.TipoAtividade.FirstOrDefaultAsync(x => x.Id == id);
            tipoAtividade.statusTipoAtividade = 1;
            await _dbContext.SaveChangesAsync();

            return tipoAtividade;
        }
    }
}
