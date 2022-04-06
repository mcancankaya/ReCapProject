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
            //CarDetailsTest();
            //UserAddTest();
            //CarAddTest();
            //UserDeleteTest();
            //UserGetAllTest();
            //CustomerGetAll();
            //UserGetById();
            //CustomerAddTest();
            //CustomerGetByUserId();
            //CustomerGetByCustomerId();
            //CustomerUpdateTest();
            //RentalAddTest();

        }

        private static void RentalAddTest()
        {
            Rental rental = new Rental();
            rental.CarId = 3;
            rental.CustomerId = 1;
            rental.RentDate = new DateTime(2022, 4, 12);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental);
        }

        private static void CustomerUpdateTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Update(new Customer { CustomerId = 1, UserId = 2, CompanyName = "Updated CompanyName" });
        }

        private static void CustomerGetByCustomerId()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetById(1);
            Console.WriteLine("Customer Id : {0}\nUser Id : {1}\nCompany Name : {2}", result.Data.CustomerId, result.Data.UserId, result.Data.CompanyName);
        }

        private static void CustomerGetByUserId()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            foreach (var item in customerManager.GetByUserId(1).Data)
            {
                Console.WriteLine("User Id : {0} \nCompany Name : {1}", item.UserId, item.CompanyName);
            }
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Deneme CompanyName" });
        }

        private static void UserGetById()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetById(1);
            Console.WriteLine(result.Data.FirstName);
        }

        private static void CustomerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine("Customer Id : {0}\nCompany Name : {1}", item.UserId, item.CompanyName);
                Console.WriteLine("------------------------------");
            }
        }

        private static void UserGetAllTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("User Id : {0}\nFirst Name : {1}\nLast Name : {2}\nEmail : {3}\nPassword: {4}", user.UserId, user.FirstName, user.LastName, user.Email, user.Password);
                Console.WriteLine("------------------------------");

            }
        }

        private static void UserDeleteTest()
        {
            User user = new User();
            user.UserId = 6;
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Delete(user);
        }

        private static void CarAddTest()
        {
            Car car = new Car();

            car.BrandId = 1;
            car.ColorId = 1;
            car.DailyPrice = 239;
            car.Description = "deneme aracı";
            car.ModelYear = 1999;

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);
        }

        private static void UserAddTest()
        {
            User user = new User();

            user.FirstName = "Deneme";
            user.LastName = "deneme1";
            user.Password = "ölksdavşlkmaşls";
            user.Email = "şövlödsfl";

            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user);
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car Name : {0}\nBrand Name : {1}\nColor Name : {2}\nDaily Price : {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                Console.WriteLine("------------------------------");
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
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
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Id : {0}\nBrand Id : {1}\nColor Id : {2}\nDescription : {3}\nModel Year : {4}\nDaily Price : {5}", car.Id, car.BrandId, car.ColorId, car.Description, car.ModelYear, car.DailyPrice);
                Console.WriteLine("------------------------------");
            }
        }
    }
}
