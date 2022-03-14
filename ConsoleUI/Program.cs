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
            Color color = new Color();
            color.ColorId = 1;
            color.ColorName = "Kırmızı";

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color);

           Console.WriteLine("Hello World!");
        }
    }
}
