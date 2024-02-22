using LearningApiAndEntity.Models;

namespace LearningApiAndEntity.Application
{
    public interface ICarService
    {

        public Task<string> CreateCarAsync(Car model);
    }
}