using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Application.Livros.Commands.CriarLivro
{
  public class CriarLivroCommand : ICriarLivroCommand
    {
        private readonly IRepository<Livro> _db;

        public CriarLivroCommand(IRepository<Livro> db)
        {
            _db = db;
        }

        public void Execute(LivroModel livroModel)
        {
          
        }
    }
}
