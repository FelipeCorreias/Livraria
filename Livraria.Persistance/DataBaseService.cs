using Livraria.Domain.Livros;
using Livraria.Persistance.Livros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Persistance
{
    public class DataBaseService : DbContext
    {
        public DataBaseService(DbContextOptions options) : base(options)
        { }

        public DbSet<Livro> Livro { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Livraria;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LivroConfiguration());
        }

    }
}
