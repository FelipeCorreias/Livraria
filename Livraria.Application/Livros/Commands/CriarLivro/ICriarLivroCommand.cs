using System.Threading.Tasks;
using Livraria.Application.Livros.Models;

namespace Livraria.Application.Livros.Commands.CriarLivro
{
    public interface ICriarLivroCommand
    {
        Task<bool> Execute(LivroInputModel livroModel, byte[] capa);
    }
}