using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    //AbstractValidator FluentValidation'dan gelir.Ve bu sınıf Car nesnesi için çalışacağından Tipini Car veriyoruz.
    //Aynı EntityFramework de yaptığımız gibi.
    public class CarValidator : AbstractValidator<Car>
    {
        //Kuralları Constructor içine yazarız.
        public CarValidator()
        {
            //Car.Description Boş olamaz. Minimum 2 karakter olmalıdır.
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);

            //DailyPrice Boş olamaz. 0'dan küçük olamaz.
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            //BrandId=1 iken DailyPrice en az 150 olmalı
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(150).When(c => c.BrandId == 1);

            //Hazır kurallar yerine kendi kurallarımızı da yazabiliriz. Örneğin;
            //Açıklama . ile bitmeli. Bunun metodunu parametre olarak veriyoruz.True Ya da False Döner.
            RuleFor(c=>c.Description).Must(EndsWithDot);
        }

        private bool EndsWithDot(string arg)
        {
            return arg.EndsWith(".");
        }
    }
}
