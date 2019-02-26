using Livraria.Application.Common.Helpers;
using Livraria.Application.Common.Linq;
using Livraria.Application.Common.Models;
using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Livros.Queries.GetLivros
{
   public class GetLivrosQuery : IGetLivrosQuery
    {
        private readonly IRepository<Livro> _db;

        public GetLivrosQuery(IRepository<Livro> db)
        {
            _db = db;
        }

        public RetornoConsulta<LivroModel> Execute(LivroBuscaModel livroModelConsulta)
        {
            var Consulta = RetornaConsultaComFiltros(livroModelConsulta);
            var totalLinhas =  Consulta.Count();
            Consulta = FiltrosHelper.OrdenacaoPaginacao(Consulta, livroModelConsulta);

            return new RetornoConsulta<LivroModel>
            {
                Data = Consulta.Select(x => new LivroModel()
                {
                    ISBN = x.ISBN,
                    Autor = x.Autor,
                    Nome = x.Nome,
                    Preco = x.Preco,
                    DataPublicacao = x.DataPublicacao,
                    Capa = x.Capa
                }).ToList(),
                TotalRows = totalLinhas
            };

        }

        private IQueryable<Livro> RetornaConsultaComFiltros(LivroBuscaModel livroModelConsulta)
        {

            var Predicate = PredicateBuilder.True<Livro>();

            if (!string.IsNullOrEmpty(livroModelConsulta.ISBN))
                Predicate = Predicate.And(p => p.ISBN == livroModelConsulta.ISBN);

            if (!string.IsNullOrEmpty(livroModelConsulta.Nome))
                Predicate = Predicate.And(p => p.Nome.Contains(livroModelConsulta.Nome));

            if (!string.IsNullOrEmpty(livroModelConsulta.Autor))
                Predicate = Predicate.And(p => p.Autor.Contains(livroModelConsulta.Autor));

            if (livroModelConsulta.Preco > 0)
                Predicate = Predicate.And(p => p.Preco == livroModelConsulta.Preco);

            return _db.GetAll().Where(Predicate);
        }

    }
}
