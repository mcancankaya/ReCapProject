using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            CarDetailsTest();

        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name : {0}\nBrand Name : {1}\nColor Name : {2}\nDaily Price : {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                Console.WriteLine("------------------------------");
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color Id : {0}\nColor Name : {1}", color.ColorId, color.ColorName);
                Console.WriteLine("------------------------------");
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Brand Id : {0}\nBrand Name : {1}", brand.BrandId, brand.BrandName);
                Console.WriteLine("------------------------------");
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Id : {0}\nBrand Id : {1}\nColor Id : {2}\nDescription : {3}\nModel Year : {4}\nDaily Price : {5}", car.Id, car.BrandId, car.ColorId, car.Description, car.ModelYear, car.DailyPrice);
                Console.WriteLine("------------------------------");
            }
        }
    }
}
