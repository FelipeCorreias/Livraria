using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Livros.Commands.EditarLivro
{
  public  class EditarLivroCommand : IEditarLivroCommand
    {
        private readonly IRepository<Livro> _db;

        public EditarLivroCommand(IRepository<Livro> db)
        {
            _db = db;
        }

        public async Task<bool> Execute(string ISBN, LivroInputModel livroModel)
        {
            var livro = await _db.GetAsync(ISBN);

            if (livro == null) {
                return false;
            }

            livro.ISBN = livroModel.ISBN;
            livro.Nome = livroModel.Nome;
            livro.Autor = livroModel.Autor;
            livro.DataPublicacao = livroModel.DataPublicacao;
            livro.Preco = livroModel.Preco;

            await _db.UpdateAsyn(livro, livroModel.ISBN);

            return true;
        }
    }
}
