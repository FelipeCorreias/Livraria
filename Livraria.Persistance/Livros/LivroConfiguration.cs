using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Persistance.Livros
{
    class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(c => c.ISBN);
            builder.Property(c => c.Nome).HasMaxLength(1500);
            builder.Property(c => c.Autor).HasMaxLength(1500);
        }
    }
}
