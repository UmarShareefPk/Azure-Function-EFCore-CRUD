using httpCRUDFunction.Api;
using httpCRUDFunction.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Configuration;
using System.Xml.Linq;

[assembly: FunctionsStartup(typeof(httpCRUDFunction.Startup))]

namespace httpCRUDFunction
{

    public class Startup : FunctionsStartup
    {
        private IConfiguration _config;
        public override void Configure(IFunctionsHostBuilder builder)
        {
            _config = builder.GetContext().Configuration;           

            string db = _config.GetConnectionString("Default");            

            if(File.Exists(db))
            {

            }

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("DataSource=D:\\GitHub\\_Mine\\DotNet\\Azure Function\\httpCRUDFunction\\httpCRUDFunction\\app.db"));        
           

            //builder.Services.AddDbContext<AppDbContext>(options =>  options.UseSqlServer(db));


            builder.Services.AddScoped<IProductAPI, ProductAPI>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var conn = _config.GetConnectionString("Default");
            
        }
    }
}
