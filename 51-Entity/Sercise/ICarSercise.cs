using _51_Entity.Models;

namespace _51_Entity.Sercise
{
    public interface IcarSercise
    {
        public Task<string> CreateCarAsync(car model);
    }
}
