using LearningApiAndEntity.Models;

namespace LearningApiAndEntity.CarServeces
{
    public interface ICarService
    {
        public Task<string> CreateCarAsnk(Car model);
        public Task<Car> UpdateCarAsynk(int id, Car model);
        public Task<bool> DeleteCarAsynk(int id);
        public Task<List<Car>> GetAllCarAsnk();
        public Task<Car> GetCarByIdAsynk(int id);
        

    }
}
