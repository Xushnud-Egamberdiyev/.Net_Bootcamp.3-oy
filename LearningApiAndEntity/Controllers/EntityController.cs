using LearningApiAndEntity.Application;
using LearningApiAndEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningApiAndEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly ICarService _carService;

        public EntityController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public async Task<string> CreateCar(Car model)
        {
            var result = await _carService.CreateCarAsync(model);

             return result;
        }
    }
}
