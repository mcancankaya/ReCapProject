using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length<5)
            {
                Console.WriteLine("Açıklama Kısmı minimum 5 karakterden oluşmalıdır.");
                return;
            }
            else if (car.DailyPrice<0)
            {
                Console.WriteLine("Günlük fiyat 0'dan küçük olamaz.");
                return;
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int brandId)
        {
            return _carDal.GetById(brandId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
