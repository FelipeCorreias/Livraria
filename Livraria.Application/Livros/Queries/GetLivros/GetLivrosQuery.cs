using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Livros.Queries.GetLivros
{
   public class GetLivrosQuery
    {
        private readonly IRepository<Livro> _db;

        public GetLivrosQuery(IRepository<Livro> db)
        {
            _db = db;
        }

        public async Task<IEnumerable<LivroModel>> Execute(LivroModelConsulta livroModelConsulta)
        {
            //implementar
            return null;
        }
    }
}
