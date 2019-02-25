using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Commands.CriarLivro;
using Livraria.Application.Livros.Models;
using Livraria.Domain.Livros;
using Livraria.Persistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Livraria.Test
{
    [TestClass]
    public class LivroTest
    {
        [TestMethod]
        public void CriarLivro()
        {
            var db = new DataBaseService();
            var repo = new Repository<DataBaseService,Livro>(db);
            var criarLivroCommand = new CriarLivroCommand(repo);

            LivroModel livro = new LivroModel
            {
                ISBN = "sdasda",
                Nome = "",
                Autor = "",
                DataPublicacao = DateTime.Now,
                Preco = 10M,
                Capa = new byte[4545]
            };

            var data = criarLivroCommand.Execute(livro);
            Assert.AreEqual(data.Result, true);

        }
    }
}
