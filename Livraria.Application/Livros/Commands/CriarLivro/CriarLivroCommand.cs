using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Livros.Commands.CriarLivro
{
    public class CriarLivroCommand : ICriarLivroCommand
    {
        private readonly IRepository<Livro> _db;

        public CriarLivroCommand(IRepository<Livro> db)
        {
            _db = db;
        }

        public async Task<bool> Execute(LivroModel livroModel)
        {
            Livro livro = new Livro();

            livro.ISBN = livroModel.ISBN;
            livro.Nome = livroModel.Nome;
            livro.Autor = livroModel.Autor;
            livro.Preco = livroModel.Preco;
            livro.Capa = livroModel.Capa;

            await _db.AddAsyn(livro);
            return true;
        }
    }
}
