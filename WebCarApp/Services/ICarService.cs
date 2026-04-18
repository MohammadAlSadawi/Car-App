using WebCarApp.Models;

namespace WebCarApp.Services
{
    public interface ICarService
    {
        Task<List<Make>> GetAllMakes();
        Task<List<VehicleType>> GetVehicleTypesByMakedId(int makeId);
        Task<List<CarModels>> GetModelsByMakedIdAndYear(int makeId, int year);
    }
}
