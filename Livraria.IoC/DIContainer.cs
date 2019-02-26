using Livraria.Application.Interfaces;
using Livraria.Application.Livros.Commands.CriarLivro;
using Livraria.Application.Livros.Queries.GetLivro;
using Livraria.Domain.Livros;
using Livraria.Persistance;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.IoC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            //PERSISTANCE
            services.AddScoped<DataBaseService>();
            services.AddScoped<IRepository<Livro>, Repository<DataBaseService, Livro>>();

            //Livros
            services.AddTransient<ICriarLivroCommand, CriarLivroCommand>();
            services.AddTransient<IGetLivroQuery, GetLivroQuery>();

        }
    }
}
