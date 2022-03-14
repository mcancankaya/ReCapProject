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
    public class BrandManager : IBrandService
    {
        IBrandDal _branddal;

        public BrandManager(IBrandDal brandDal)
        {
            _branddal = brandDal;
        }

        public void Add(Brand brand)
        {
            _branddal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _branddal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _branddal.GetAll();
        }

        public void Update(Brand brand)
        {
            _branddal.Update(brand);
        }
    }
}
