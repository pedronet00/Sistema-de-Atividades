using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio 
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public LivroRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<LivroModel> buscarLivro(int id)
        {
            return await _dbContext.Livro.FirstOrDefaultAsync(x=>x.idLivro == id);
        }

        public async Task<List<LivroModel>> buscarLivros()
        {
            return await _dbContext.Livro.ToListAsync();
        }

        public async Task<LivroModel> desativarLivro(int id)
        {
            LivroModel livro = await _dbContext.Livro.FirstOrDefaultAsync(x => x.idLivro == id);
            livro.statusLivro = 0;
            await _dbContext.SaveChangesAsync();

            return livro;
        }


        public async Task<LivroModel> cadastrarLivro(LivroModel livro)
        {
            await _dbContext.Livro.AddAsync(livro);
            await _dbContext.SaveChangesAsync();

            return livro;
        }
    }
}
