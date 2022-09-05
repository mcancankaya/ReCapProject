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
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.add, admin")]
        public IResult Add(Customer customer)
        {
            var resultRules = BusinessRules.Run(CheckIfAlreadyExist(customer.CompanyName));
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        [SecuredOperation("customer.delete, admin")]
        public IResult Delete(Customer customer)
        {
            
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }


        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==customerId));
        }

        public IDataResult<List<Customer>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.UserId==userId));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.update, admin")]
        public IResult Update(Customer customer)
        {
            var resultRules = BusinessRules.Run(CheckIfAlreadyExist(customer.CompanyName));
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        //Rules
        private IResult CheckIfAlreadyExist(string companyName)
        {
            var result = _customerDal.GetAll(c => c.CompanyName == companyName).Any();
            if (result != null)
            {
                return new ErrorResult(Messages.CustomerAlreadyExist);
            }

            return new SuccessResult();
        }
    }
}
