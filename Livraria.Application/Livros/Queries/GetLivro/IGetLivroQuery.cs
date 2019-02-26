using System.Threading.Tasks;
using Livraria.Application.Livros.Models;

namespace Livraria.Application.Livros.Queries.GetLivro
{
    public interface IGetLivroQuery
    {
        Task<LivroModel> Execute(string ISBN);
    }
}