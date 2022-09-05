using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("color.add,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            var resultRules = BusinessRules.Run(CheckIfAlreadyExist(color.ColorName));
            if (!resultRules.Success)
            {
                return resultRules;
            }

            _colorDal.Add(color);
            return new SuccessResult();
        }

        [SecuredOperation("color.delete,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=> c.ColorId==colorId));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("color.update,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }

        //Rules

        private IResult CheckIfAlreadyExist(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (result != null)
            {
                return new ErrorResult(Messages.ColorExist);
            }

            return new SuccessResult();
        }
    }
}
