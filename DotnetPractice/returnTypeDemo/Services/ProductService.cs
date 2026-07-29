using returnTypeDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace returnTypeDemo.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> ProductList = new List<Product>()
        {
              new Product { Id = 1, Name = "HP Laptop", Category = "Electronics", Price = 55000, InStock = true},
              new Product { Id = 2, Name = "iPhone 15", Category = "Mobiles", Price = 125000, InStock = true },
            new Product { Id = 3, Name = "Samsung TV", Category = "Electronics", Price = 78000, InStock = false },
            new Product { Id = 4, Name = "Nike Shoes", Category = "Footwear", Price = 8500, InStock = true },
            new Product { Id = 5, Name = "Levi’s Jeans", Category = "Clothing", Price = 4500, InStock = true },
            new Product { Id = 6, Name = "Levi’s Jeans", Category = "Clothing", Price = 4500, InStock = true },
            new Product { Id = 7, Name = "Levi’s Jeans", Category = "Clothing", Price = 4500, InStock = true },
            new Product { Id = 8, Name = "Levi’s Jeans", Category = "Clothing", Price = 4500, InStock = true },
            new Product { Id = 9, Name = "Levi’s Jeans", Category = "Clothing", Price = 4500, InStock = true },
            new Product { Id = 10, Name = "Levi’s Jeans", Category = "Clothing", Price = 4500, InStock = true }
        };


        public ActionResult<List<Product>> getData()
        {

            var prdList = ProductList.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price, InStock = p.InStock
            }).ToList();
            return prdList;
        }

        //public static async Task<List<Product>> GetAllProductsAsync()
        //{
        //    await Task.Delay(400); // Simulate async DB call
        //    return ProductList;
        //}

        public ActionResult<Product> createProduct(Product prd)
        {
            var product = new Product
            {
                Id = prd.Id,
                Name = prd.Name,
                Category = prd.Category,
                Price = prd.Price,
                InStock = prd.InStock
            };

            ProductList.Add(product);

            return product;
        }
    }
}
