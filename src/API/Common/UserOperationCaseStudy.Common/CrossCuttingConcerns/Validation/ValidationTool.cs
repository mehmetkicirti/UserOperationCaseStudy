using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Common.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public async static Task ValidateAsync(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = await validator.ValidateAsync(context);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}
