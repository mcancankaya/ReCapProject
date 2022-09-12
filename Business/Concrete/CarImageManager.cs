using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var resultUpload = _fileHelper.Upload(file,PathConstants.ImagePath);
            if (!resultUpload.Success)
            {
                return resultUpload;
            }
            carImage.ImagePath = resultUpload.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var resultOfDelete = _carImageDal.Get(c=> c.Id==carImage.Id);

            var result = _fileHelper.Delete(PathConstants.ImagePath + resultOfDelete.ImagePath);
            if (!result.Success)
            {
                return result;
            }

            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result,Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var resultRules = BusinessRules.Run(CheckIfCarImageExists(carId));

            if (resultRules != null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultCarImage(carId).Data);
            }
            var result = _carImageDal.GetAll(c=> c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(result,Messages.CarImagesListed);
        }

        
        public IResult Update(IFormFile file, CarImage carImage)
        {
            
            var result = _fileHelper.Update(file, PathConstants.ImagePath + carImage.ImagePath, PathConstants.ImagePath);

            if (!result.Success)
            {
                return result;
            }
            var resultUpdateCarImage = _carImageDal.Get(c=> c.ImagePath== carImage.ImagePath);

            carImage.Id = resultUpdateCarImage.Id;
            carImage.CarId = resultUpdateCarImage.CarId;
            carImage.Date = DateTime.Now;
            carImage.ImagePath = result.Message;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        //Business Rules

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "default_image.png"
            });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
