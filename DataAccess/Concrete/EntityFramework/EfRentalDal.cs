using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from rental in context.Rentals
                    join car in context.Cars on rental.CarId equals car.Id
                    join b in context.Brands on car.BrandId equals b.BrandId
                    join c in context.Customers on rental.CustomerId equals c.CustomerId
                    join u in context.Users on c.UserId equals u.UserId
                    select new RentalDetailDto()
                    {
                        FullName = u.FirstName+" "+u.LastName,
                        BrandName = b.BrandName,
                        ReturnDate = Convert.ToDateTime(rental.ReturnDate),
                        RentalDate = rental.RentDate

                    };
                return result.ToList();
            }
            
        }
    }
}
