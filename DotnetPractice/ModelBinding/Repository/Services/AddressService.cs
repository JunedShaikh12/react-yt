using ModelBinding.Models;

namespace ModelBinding.Repository.Services
{
    public class AddressService
    {

        public static List<Country> Countries = new List<Country>
        {
                new Country { CountryId = 1, Name = "India" },
                new Country { CountryId = 2, Name = "United States" },
                new Country { CountryId = 3, Name = "Canada" },
                new Country { CountryId = 4, Name = "United Kingdom" }
        };

        public static List<State> State = new List<State>
        {
                new State { StateId = 1, Name = "California", CountryId = 2 },
                new State { StateId = 2, Name = "Texas", CountryId = 2 },
                new State { StateId = 3, Name = "British Columbia", CountryId = 3 },
                new State { StateId = 4, Name = "Ontario", CountryId = 3 },
                new State { StateId = 5, Name = "England", CountryId = 4 },
                new State { StateId = 6, Name = "Maharashtra", CountryId = 1 },
                new State { StateId = 7, Name = "Delhi", CountryId = 1 }
        };

        public static List<City> City = new List<City>
        {
            new City { CityId = 1, Name = "Los Angeles", StateId = 1 },
                new City { CityId = 2, Name = "San Francisco", StateId = 1 },
                new City { CityId = 3, Name = "Houston", StateId = 2 },
                new City { CityId = 4, Name = "Dallas", StateId = 2 },
                new City { CityId = 5, Name = "Vancouver", StateId = 3 },
                new City { CityId = 6, Name = "Toronto", StateId = 4 },
                new City { CityId = 7, Name = "London", StateId = 5 },
                new City { CityId = 8, Name = "Mumbai", StateId = 6 },
                new City { CityId = 9, Name = "Pune", StateId = 6 }
        };

        public static List<Product> initialProducts = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Apple iPhone 14",
                    Category = "Electronics",
                    Price = 999,
                    Quantity = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "Samsung Galaxy S22",
                    Category = "Electronics",
                    Price = 899,
                    Quantity = 40
                },
                new Product
                {
                    Id = 3,
                    Name = "Sony WH-1000XM4 Headphones",
                    Category = "Electronics",
                    Price = 349,
                    Quantity = 30
                },
                new Product
                {
                    Id = 4,
                    Name = "Nike Air Zoom Pegasus",
                    Category = "Footwear",
                    Price = 120,
                    Quantity = 100
                },
                new Product
                {
                    Id = 5,
                    Name = "Adidas Ultraboost",
                    Category = "Footwear",
                    Price = 180,
                    Quantity = 80
                },
                new Product
                {
                    Id = 6,
                    Name = "Organic Apples (1kg)",
                    Category = "Groceries",
                    Price = 4,
                    Quantity = 200
                },
                new Product
                {
                    Id = 7,
                    Name = "Organic Bananas (1 Dozen)",
                    Category = "Groceries",
                    Price = 3,
                    Quantity = 150
                }
            };


        public List<Country> getAllCountries ()
        {
            return Countries.ToList();
        }
        public List<State> getAllStates()
        {
            return State.ToList();
        }
        public List<Product> getAllProducts()
        {
            return initialProducts.ToList();
        }
    }
}
