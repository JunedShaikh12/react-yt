using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ModelBinding.Models;
using ModelBinding.Repository;
using ModelBinding.Repository.Services;
using System.Text.Json;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly LocationRespository _respository;
        private readonly AddressService _addressService;
        public LocationController(LocationRespository respository, IDistributedCache cache, AddressService addressService)
        {
            _respository = respository;
            _cache = cache;
            _addressService = addressService;

        }

        [HttpGet("allCountries")]
        public IActionResult getCountriesData()
        {
            var Countires = _respository.GetCountriesAsync();
            return Ok(Countires);
        }


        [HttpGet("allStates")]
        public IActionResult getStates(int CountryId)
        {
            var states = _respository.GetStates(CountryId);
            return Ok(states);
        }




        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var cacheKey = "GET_ALL_PRODUCTS";
            List<Product> products;
            try
            {
                // Attempt to retrieve the product list from Redis cache.
                var cachedData = await _cache.GetStringAsync(cacheKey);
                if (!string.IsNullOrEmpty(cachedData))
                {
                    // Deserialize JSON string back to List<Product>.
                    products = JsonSerializer.Deserialize<List<Product>>(cachedData) ?? new List<Product>();
                }
                else
                {
                    // Cache miss: fetch products from the database.
                    //products = await _context.Products.AsNoTracking().ToListAsync();
                    products = _addressService.getAllProducts();
                    if (products != null)
                    {
                        // Serialize the product list to a JSON string.
                        var serializedData = JsonSerializer.Serialize(products);
                        // Define cache options (using sliding expiration).
                        var cacheOptions = new DistributedCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                        // Store the serialized data in Redis.
                        await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions);
                    }
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Return a 500 response if any error occurs.
                return StatusCode(500, new { message = "An error occurred while retrieving products.", details = ex.Message });
            }
        }
    }
}
