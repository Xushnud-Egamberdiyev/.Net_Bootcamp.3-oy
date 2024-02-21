using _51_Entity.Infrastructure;
using _51_Entity.Models;

namespace _51_Entity.Sercise
{
    public class CarServese : IcarSercise
    {
        public readonly ApplicationDbContext _application;
        public CarServese(ApplicationDbContext dbContext)
        {
            _application = dbContext;
        }
        public async Task<string> CreateCarAsync(car model)
        {
            await _application.Cars.AddAsync(model);
            await _application.SaveChangesAsync();

            return "Malumotlar yaratildi";
        }
    }
}
