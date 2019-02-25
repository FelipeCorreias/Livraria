using Livraria.Application.Livros.Models;

namespace Livraria.Application.Livros.Commands.CriarLivro
{
    public interface ICriarLivroCommand
    {
        void Execute(LivroModel livroModel);
    }
}