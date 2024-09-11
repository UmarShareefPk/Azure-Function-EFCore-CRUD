using httpCRUDFunction.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpCRUDFunction.Data
{
    public class AppDbContext : DbContext
    {
        // private readonly IConfiguration _config;

        public AppDbContext()
        {
            
        }
        public AppDbContext( DbContextOptions options) : base(options)
        {
           // _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            //string db =  _config.GetConnectionString("Default");
           // optionsBuilder.UseSqlite(@"DataSource=Data\app.db");
        }

        public DbSet<Product> Products { get; set; }
    }
}
