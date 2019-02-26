using System.Threading.Tasks;

namespace Livraria.Application.Livros.Commands.DeletarLivro
{
    public interface IDeletarLivroCommand
    {
        Task<bool> Execute(string ISBN);
    }
}