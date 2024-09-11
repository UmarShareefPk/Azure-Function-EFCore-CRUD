using httpCRUDFunction.Data;
using httpCRUDFunction.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpCRUDFunction.Api
{
    public class ProductAPI : IProductAPI
    {
        private AppDbContext _dbContext;
        public ProductAPI(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> InsertNewProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            if(_dbContext.Products.Count() == 0)
                return new List<Product>();

            return await _dbContext.Products.ToListAsync();

        }

    }
}
