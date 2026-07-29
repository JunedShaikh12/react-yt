using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using returnTypeDemo.Models;
using returnTypeDemo.Services;

namespace returnTypeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productservice)
        {
            _productService = productservice;
        }
        [HttpGet("GetProductCount" , Name = "Get")]
        public ActionResult<Product> Get()
        {
            var prd =  _productService.getData();
            return Ok(prd);
        }

        [HttpPost]

        public async Task<ActionResult<Product>> PostMethod(int Id , [FromBody] Product prd)
        {
            var newProduct = _productService.createProduct(prd);
            return CreatedAtRoute("Get", new {message = "heyyyy"}, newProduct);
        }
    }
}
