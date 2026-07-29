using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using ModelBinding.Models;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace ModelBinding.Repository.Services
{
    public class PService : IPService
    {
       

        public static List<PModel> products = new List<PModel> {

        new PModel { Id = 1, Name = "Laptop", Price = 65000, Category = "Electronics", IsActive = true, Stock = 20, Rating = 4.5, CreatedDate = DateTime.Now.AddDays(-10) },
        new PModel { Id = 2, Name = "Mobile", Price = 65000, Category = "Electronics", IsActive = true, Stock = 20, Rating = 4.5, CreatedDate = DateTime.Now.AddDays(-10) },
        new PModel { Id = 3, Name = "Headphones", Price = 65000, Category = "Electronics", IsActive = true, Stock = 20, Rating = 4.5, CreatedDate = DateTime.Now.AddDays(-10) },
        new PModel { Id = 4, Name = "laptop", Price = 65000, Category = "Electronics", IsActive = true, Stock = 20, Rating = 4.5, CreatedDate = DateTime.Now.AddDays(-10) },
        new PModel { Id = 5, Name = "metal", Price = 65000, Category = "Electronics", IsActive = true, Stock = 20, Rating = 4.5, CreatedDate = DateTime.Now.AddDays(-10) },
        new PModel { Id = 6, Name = "Laptop", Price = 65000, Category = "Electronics", IsActive = true, Stock = 20, Rating = 4.5, CreatedDate = DateTime.Now.AddDays(-10) }
        };


        public IEnumerable<PModel> GetAll()
        {
            return products;
        }

        public PModel ? GetById(int id)
        {
            return products.FirstOrDefault(P => P.Id == id);
        }

       public IEnumerable<PModel> Searchh( string? Name)
        {
            var productFound = products.Where(p => p.Name.Equals(Name, StringComparison.OrdinalIgnoreCase)).ToList();
            return productFound;
        }

        public IEnumerable<PModel> AddPrd(PModel product)
        {
            var newProduct = new PModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                IsActive = product.IsActive,
                Stock = product.Stock,
            };
            products.Add(newProduct);
             return new List<PModel>
                {
                newProduct
                 };
        }
    }
}
    