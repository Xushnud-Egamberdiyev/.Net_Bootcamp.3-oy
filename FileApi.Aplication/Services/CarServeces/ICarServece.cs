using FileApi.Domen.Entitys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileApi.Aplication.Services.CarServeces
{
    public interface ICarServece
    {
        public Task<bool> CreateCar(CarDTO carDTO);
        public Task<Car> UpdateCar(int id, CarDTO carDTO);
        public Task<List<Car>> GetAlCar();
        public Task<Car> GetById(int id);
        public Task<bool> DeleteCar(int  id);
    }
}
