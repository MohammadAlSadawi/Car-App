using Microsoft.Extensions.Caching.Memory;
using WebCarApp.Models;
using WebCarApp.Models.Apis;

namespace WebCarApp.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _http;
        private readonly IMemoryCache _cache;
        private const string MAKES_KEY = "all_makes";
        public CarService(HttpClient http,IMemoryCache cache)
        {
            _http = http;
            _cache = cache;
        }
        public async Task<List<Make>> GetAllMakes()
        {
            if (_cache.TryGetValue(MAKES_KEY, out List<Make> cached))
            {
               
                return cached;
            }
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<Make>>(
           "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
                _cache.Set(MAKES_KEY, response.Results, TimeSpan.FromHours(24));

                return response?.Results ?? new List<Make>();
               
            }
            catch (Exception ex) {
                return new List<Make>();
            }
           
            
        }

        public async Task<List<CarModels>> GetModelsByMakedIdAndYear(int makeId, int year)
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<CarModels>>(
                ($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json"));
            return response?.Results ?? new List<CarModels>();
      
        }

        public async Task<List<VehicleType>> GetVehicleTypesByMakedId(int makeId)
        {
        
            var response = await _http.GetFromJsonAsync<ApiResponse<VehicleType>>(
                ($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json"));

            return response?.Results ?? new List<VehicleType>();
            
        }
    }
}
