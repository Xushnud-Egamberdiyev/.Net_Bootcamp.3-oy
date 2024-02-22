
using LearningApiAndEntity.Infracture;
using LearningApiAndEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApiAndEntity.CarServeces
{
    public class CarServece : ICarService
    {
        private readonly AplicationDbContext _context;
        public CarServece(AplicationDbContext aplication)
        {
            _context = aplication;
        }
        public async Task<string> CreateCarAsnk(Car model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Malumot yaratildi";
        }

        public async Task<Car> UpdateCarAsynk(int id, Car model)
        {
            var car = _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();

                return model;
            }
            return null;

        }
        public async Task<bool> DeleteCarAsynk(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _context.Remove(car);
                _context.SaveChangesAsync();

                return true;
            }
            return false;
            
        }

        public Task<List<Car>> GetAllCarAsnk()
        {
            var cars = _context.Cars.ToListAsync();
            return cars;
        }

        public Task<Car> GetCarByIdAsynk(int id)
        {

            var car = _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car != null)
            {
                return car;
            }
            return null;
        }

    }

}
