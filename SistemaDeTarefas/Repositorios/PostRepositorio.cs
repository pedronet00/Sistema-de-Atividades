using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class PostRepositorio : IPostRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public PostRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PostModel> inserirPost(PostModel post)
        {
            await _dbContext.Post.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            return post;
        }

        public async Task<List<PostModel>> listarPosts()
        {
            return await _dbContext.Post.ToListAsync();
        }
    }
}
