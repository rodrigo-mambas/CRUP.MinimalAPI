﻿using CRUP.MinimalAPI.Entities;

namespace CRUP.MinimalAPI.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> GetLivros();
        Task<Livro> GetLivro(int id);
        Task<Livro> AddLivro(Livro livro);
        Task<Livro> DeleteLivro(int id);
        Task<Livro> UpdateLivro(Livro livro);
    }
}
