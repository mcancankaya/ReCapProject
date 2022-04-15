using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //Gönderilen validatorType bir validator değilse,yani fluentValidation IValidator tipinde değilse hata ver.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir Doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection yapısı -> Gelen tipe göre çalışma anında gelen validatorType'ın instance'ını oluştur.
            
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //ValidatorType'ın base sınıfına git, onun çalıştığı tipi bul. [0] ilk parametredir sınıfAdi(entity1,entity2) gibi düşün.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //invocation metoda karşılık geliyor. İnvocation'ın yani metodun parametrelerine bak validatorType'ın parametresine eşit olanları bul ve entities e ata.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            //Parametrelerin hepsini al, validationtool ile validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
