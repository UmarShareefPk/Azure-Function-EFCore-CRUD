using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using httpCRUDFunction.Data;
using httpCRUDFunction.Api;
using httpCRUDFunction.Model;
using System.Collections.Generic;

namespace httpCRUDFunction
{
    public  class ProductCRUD
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProductAPI _productApi;
        public ProductCRUD(AppDbContext context, IProductAPI productAPI)
        {
            _appDbContext = context;
            _productApi = productAPI;
        }

        [FunctionName("Product")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            if(req.Method == HttpMethods.Get)
            {          
                List<Product> products = await _productApi.GetAllProducts();
                return new OkObjectResult(products);
            }

            if (req.Method == HttpMethods.Post)
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var product = JsonConvert.DeserializeObject<Product>(requestBody);
                await _productApi.InsertNewProduct(product);
                return new OkObjectResult("New Product has been added.");
            }

                
          

            string responseMessage  = "No method was executed.";

            return new OkObjectResult(responseMessage);
        }


    }
}
