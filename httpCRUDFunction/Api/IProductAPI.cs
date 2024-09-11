using httpCRUDFunction.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace httpCRUDFunction.Api
{
    public interface IProductAPI
    {
        Task<List<Product>> GetAllProducts();
        Task<bool> InsertNewProduct(Product product);
    }
}