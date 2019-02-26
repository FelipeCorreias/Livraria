using Livraria.Application.Common.Models;
using Livraria.Application.Livros.Models;

namespace Livraria.Application.Livros.Queries.GetLivros
{
    public interface IGetLivrosQuery
    {
        RetornoConsulta<LivroModel> Execute(LivroBuscaModel livroModelConsulta);
    }
}