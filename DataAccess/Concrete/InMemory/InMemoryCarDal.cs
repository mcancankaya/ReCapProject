using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car { Id=1, BrandId=1, ColorId=1, ModelYear=2013, DailyPrice=250,Description="Dacia Sandero"},
                new Car { Id=2, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=450,Description="Dacia Logan"},
                new Car { Id=3, BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=400,Description="Volkswagen Passat Aşiret Paket"},
                new Car { Id=4, BrandId=2, ColorId=2, ModelYear=2019, DailyPrice=500,Description="Volkswagen Passat Aşiret Çocuğu Paket"},
                new Car { Id=5, BrandId=3, ColorId=3, ModelYear=2021, DailyPrice=150,Description="BMW Kız düşürme garanti paketi"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c=> c.BrandId==brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
