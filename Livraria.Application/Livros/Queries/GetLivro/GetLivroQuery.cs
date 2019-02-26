using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Livros.Queries.GetLivro
{
  public  class GetLivroQuery : IGetLivroQuery
    {

        private readonly IRepository<Livro> _db;

        public GetLivroQuery(IRepository<Livro> db)
        {
            _db = db;
        }

        public async Task<LivroModel> Execute(string ISBN)
        {
            Livro livro = await _db.GetAsync(ISBN);

            if (livro == null) {
                return null;
            }

            return new LivroModel()
            {
                ISBN = livro.ISBN,
                Autor = livro.Autor,
                Nome = livro.Nome,
                DataPublicacao = livro.DataPublicacao,
                Preco = livro.Preco,
                Capa = livro.Capa
            };
        }

      
    }
}
