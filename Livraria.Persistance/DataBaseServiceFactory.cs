using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Livraria.Persistance
{
    public class DataBaseServiceFactory : IDesignTimeDbContextFactory<DataBaseService>
    {
        public DataBaseService Create()
        {
             return CreateDbContext(null);
        }

        private DataBaseService Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));

            var optionsBuilder =
                new DbContextOptionsBuilder<DataBaseService>();

            optionsBuilder.UseSqlServer(connectionString);

            return new DataBaseService(optionsBuilder.Options);
        }

        public DataBaseService CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DataBaseService>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new DataBaseService(builder.Options);
        }
    }
}
