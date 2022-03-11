using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Car car = new Car();
            car.Id = 1;
            car.BrandId = 1;
            car.ColorId = 1;
            car.ModelYear = 2021;
            car.DailyPrice =1000;
            car.Description = "BMW X5";
            carManager.Add(car);

           foreach (var item in carManager.GetAll())
           {
               Console.WriteLine("Id : "+item.Id+"\nBrand Id : "+item.BrandId+
                   "\nColor Id : "+item.ColorId+"\nModel Year : "+item.ModelYear+
                   "\nDaily Price : "+item.DailyPrice+"\nDescription : "+item.Description);
               Console.WriteLine("---------------------------");
           }
           Console.WriteLine("Hello World!");
        }
    }
}
