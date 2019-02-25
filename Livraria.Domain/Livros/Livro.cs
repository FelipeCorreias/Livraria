using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Livros
{
   public class Livro
    {
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public byte[] Capa { get; set; }
    }
}
