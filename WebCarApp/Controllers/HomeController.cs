using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCarApp.Models;
using WebCarApp.Services;

namespace WebCarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        public HomeController(ILogger<HomeController> logger,ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SearchMakes(string Make_Name)
        {
            if (string.IsNullOrWhiteSpace(Make_Name) || Make_Name.Length < 2)
                return Json(new List<object>());

            var allMakes = await _carService.GetAllMakes();

            var results = allMakes
                .Where(m => m.Make_Name.Contains(Make_Name, StringComparison.OrdinalIgnoreCase))
                .Take(20)
                .Select(m => new { makeId = m.Make_ID, makeName = m.Make_Name })
                .ToList();

            return Json(results);
        }
        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes(int makeId)
        {
            if (makeId <= 0)
                return Json(new List<object>());

            var types = await _carService.GetVehicleTypesByMakedId(makeId);

            var result = types.Select(t => new
            {
                t.VehicleTypeId,
                t.VehicleTypeName
            }).ToList();

            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetModels(int makeId, int year)
        {
            if (makeId <= 0 || year <= 0)
                return Json(new List<object>());

            var models = await _carService.GetModelsByMakedIdAndYear(makeId, year);

            var result = models.Select(m => new
            {
                modelName = m.Model_Name
            }).ToList();

            return Json(result);
        }

    }
}
