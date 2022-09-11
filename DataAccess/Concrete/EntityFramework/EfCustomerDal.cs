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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectDBContext>, ICustomerDal
    {
        public List<CustomerDetailDto> geCustomerDetailDtos()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.UserId
                    select new CustomerDetailDto()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
