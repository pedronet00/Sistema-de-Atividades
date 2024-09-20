using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;


namespace SistemaDeTarefas.Repositorios
{
    public class AtividadeRepositorio : IAtividadeRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public AtividadeRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AtividadeModel>> GetAllAtividades()
        {
            return await _dbContext.Atividade.ToListAsync();
        }

        public async Task<AtividadeModel> GetAtividadeById(string id)
        {
            return await _dbContext.Atividade.FindAsync(id);
        }

        public async Task<AtividadeModel> CreateAtividade(AtividadeModel atividade)
        {
            _dbContext.Atividade.Add(atividade);
            await _dbContext.SaveChangesAsync();
            return atividade;
        }

        public async Task<AtividadeModel> UpdateAtividade(AtividadeModel atividade)
        {
            _dbContext.Entry(atividade).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return atividade;
        }

        public async Task<bool> DeleteAtividade(string id)
        {
            var atividade = await _dbContext.Atividade.FindAsync(id);
            if (atividade == null)
            {
                return false;
            }

            _dbContext.Atividade.Remove(atividade);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
