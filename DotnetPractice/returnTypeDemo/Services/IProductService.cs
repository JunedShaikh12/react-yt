using Microsoft.AspNetCore.Mvc;
using returnTypeDemo.Models;

namespace returnTypeDemo.Services
{
    public interface IProductService
    {
        ActionResult<List<Product>> getData();
        //Task<List<Product>> GetAllProductsAsync();

         ActionResult<Product> createProduct(Product prd);
    }
}
