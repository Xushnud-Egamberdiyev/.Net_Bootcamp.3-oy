using FileApi.Domen.Entitys.Models;
using FileApi.n.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileApi.Aplication.Services.CarServeces
{
    public class CarServece : ICarServece
    {
        private readonly ApDbContext _context;

        public CarServece(ApDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCar(CarDTO carDTO)
        {
            try
            {
                var model = new Car()
                {
                    Model = carDTO.Model,
                    Name = carDTO.Name,
                    Salary = carDTO.Salary,
                    Year = carDTO.Year,
                };

                await _context.Cars.AddAsync(model);
                await _context.SaveChangesAsync();
                if(model == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCar(int id)
        {
            var model = await _context.Cars.FirstOrDefaultAsync(x =>  x.Id == id);
            if(model == null)
            {
                return false;
            }
            else
            {
                _context.Cars.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Car>> GetAlCar()
        {
            try
            {
                var model = await _context.Cars.ToListAsync();
                if (model != null)
                {
                    return model;
                }
                else
                {
                    return new List<Car>();
                }
            }
            catch
            {
                return new List<Car>();
            }
        }

        public async Task<Car> GetById(int id)
        {
            try
            {
                var model = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if(model  != null)
                {
                    return model;
                }
                else
                {
                    return new Car();
                }
            }
            catch
            {
                return new Car();
            }
        }

        public async Task<Car> UpdateCar(int id, CarDTO carDTO)
        {
            try
            {
                var model = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if(model != null)
                {
                    model.Model = carDTO.Model;
                    model.Name = carDTO.Name;
                    model.Salary = carDTO.Salary;
                    model.Year = carDTO.Year;
                }
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                return new Car();
            }
        }
    }
}
