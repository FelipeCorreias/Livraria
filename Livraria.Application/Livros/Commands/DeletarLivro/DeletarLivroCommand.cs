using Livraria.Application.Interfaces;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Livros.Commands.DeletarLivro
{
   public class DeletarLivroCommand : IDeletarLivroCommand
    {
        private readonly IRepository<Livro> _db;

        public DeletarLivroCommand(IRepository<Livro> db)
        {
            _db = db;
        }

        public async Task<bool> Execute(string ISBN)
        {
            var livro = await _db.GetAsync(ISBN);

            if (livro == null)
            {
                return false;
            }

            await _db.DeleteAsyn(livro);

            return true;
        }
    }
}
