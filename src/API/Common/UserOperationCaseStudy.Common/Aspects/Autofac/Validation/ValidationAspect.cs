using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Constants;
using UserOperationCaseStudy.Common.CrossCuttingConcerns.Validation;
using UserOperationCaseStudy.Common.Helpers.Interceptors;

namespace UserOperationCaseStudy.Common.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(ExceptionConstants.VALIDATION_TYPE_ERROR);
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0]; // AbstractValidator<User> => It takes User
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.ValidateAsync(validator, entity).GetAwaiter().GetResult();
            }
        }
    }
}
