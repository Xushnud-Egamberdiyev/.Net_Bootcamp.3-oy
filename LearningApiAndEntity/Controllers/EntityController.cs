using LearningApiAndEntity.CarServeces;
using LearningApiAndEntity.Infracture;
using LearningApiAndEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningApiAndEntity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly ICarService _service;


        public EntityController(ICarService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<string> CreateCar(Car model)
        {
            var result =  await _service.CreateCarAsnk(model);

            return result;
        }

        [HttpGet]
        public async Task<List<Car>> GetAllCars()
        {
            var result = await _service.GetAllCarAsnk();

            return result;
        }

        [HttpGet]
        public async Task<Car> GetByIdCars(int id)
        {
            var result = await _service.GetCarByIdAsynk(id);

            return result;
        }

        [HttpPut]
        public async Task<Car>  UpdateCarAsync(int id, Car model)
        {
            var result = await _service.UpdateCarAsynk(id, model);

            return result;
        }

        [HttpDelete]
        public async Task<bool> DeleteCarAsync(int id)
        {
            var result = await _service.DeleteCarAsynk(id);

            return result;
        }
    }
}
