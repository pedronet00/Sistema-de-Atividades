﻿using Microsoft.EntityFrameworkCore;
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

        async public Task<PostModel> editarPost(PostModel postModel, int id)
        {
            PostModel post = await _dbContext.Post.FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
            {
                throw new Exception("Post não encontrado.");
            }

            post.autorPost= postModel.autorPost;
            post.dataPost = postModel.dataPost;
            post.tituloPost = postModel.tituloPost;
            post.descricaoPost = postModel.descricaoPost;
            post.textoPost = postModel.textoPost;

            _dbContext.Post.Update(post);
            await _dbContext.SaveChangesAsync();

            return post;
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
