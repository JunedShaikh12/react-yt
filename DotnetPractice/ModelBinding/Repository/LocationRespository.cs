using Microsoft.Extensions.Caching.Memory;
using ModelBinding.Models;
using ModelBinding.Repository.Services;

namespace ModelBinding.Repository
{


    public class LocationRespository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly AddressService _addressService;
        private readonly TimeSpan _cachekhtmTime = TimeSpan.FromMinutes(30);

        public LocationRespository(IMemoryCache memoryCache , AddressService addressService)
        {
            _memoryCache = memoryCache;
            _addressService = addressService;
        }

        public List<Country> allCountries()
        {
           var Countries=  _addressService.getAllCountries();
            return Countries;
        }
        public async Task<List<Country>> GetCountriesAsync()
        {
            var cacheKey = "Countries"; 

            if(!_memoryCache.TryGetValue(cacheKey,out List<Country>? countries))
            {
                countries = allCountries().ToList();
                _memoryCache.Set(cacheKey, countries, _cachekhtmTime);
            }
            return countries ?? new List<Country>();
        }

        public async Task<List<State>> GetStates (int CountryId)
        {
            string cacheKey = $"States_{CountryId}";
            if (!_memoryCache.TryGetValue(cacheKey, out List<State>? states))
            {
                //states = await _addressService.State
                //                       .Where(s => s.CountryId == CountryId)
                //                       .AsNoTracking()
                //                       .ToListAsync();

                states =  _addressService.getAllStates().Where(p=> p.CountryId == CountryId).ToList();
                _memoryCache.Set(cacheKey, states, _cachekhtmTime);
            }
            return states ?? new List<State>();
        }
    }
}
