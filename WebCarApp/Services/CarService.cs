using WebCarApp.Models;
using WebCarApp.Models.Apis;

namespace WebCarApp.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _http;

        public CarService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Make>> GetAllMakes()
        {
       
            var response = await _http.GetFromJsonAsync<ApiResponse<Make>>(
            "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");

            return response?.Results ?? new List<Make>();
            
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
                ($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/makeId/{makeId}?format=json"));

            return response?.Results ?? new List<VehicleType>();
            
        }
    }
}
