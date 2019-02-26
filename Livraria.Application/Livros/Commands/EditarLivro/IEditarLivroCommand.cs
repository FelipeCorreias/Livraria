using System.Threading.Tasks;
using Livraria.Application.Livros.Models;

namespace Livraria.Application.Livros.Commands.EditarLivro
{
    public interface IEditarLivroCommand
    {
        Task<bool> Execute(string ISBN, LivroInputModel livroModel);
    }
}