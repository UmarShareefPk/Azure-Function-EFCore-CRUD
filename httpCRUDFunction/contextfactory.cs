using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using httpCRUDFunction.Data;
using Microsoft.Extensions.Configuration;

namespace httpCRUDFunction
{
    public class ProductContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json")
             .Build();

            var defaultConnectionString = configuration.GetConnectionString("Default");

           // optionsBuilder.UseSqlServer(defaultConnectionString);
            optionsBuilder.UseSqlite(defaultConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
