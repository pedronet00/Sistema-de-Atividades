﻿using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IPostRepositorio
    {

        Task<List<PostModel>> listarPosts();

        Task<PostModel> inserirPost(PostModel post);

        Task<PostModel> editarPost(PostModel post, int id);
    }
}
