using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("brand.add,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            var resultRules = BusinessRules.Run(CheckIfAlreadyExist(brand.BrandName));
            if (!resultRules.Success)
            {
                return resultRules;
            }

            _brandDal.Add(brand);
            return new SuccessResult();
        }

        [SecuredOperation("brand.delete,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=> b.BrandId==brandId));
        }

        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("brand.update,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            var resultRules = BusinessRules.Run(CheckIfAlreadyExist(brand.BrandName));
            if (!resultRules.Success)
            {
                return resultRules;
            }
            _brandDal.Update(brand);
            return new SuccessResult();
        }

        //Business Rules
        private IResult CheckIfAlreadyExist(string brandName)
        {
            var result = _brandDal.GetAll(b=>b.BrandName == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandAlreadyExist);
            }

            return new SuccessResult();
        }
    }
}
