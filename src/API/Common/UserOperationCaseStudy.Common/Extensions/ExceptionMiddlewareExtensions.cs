using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Middlewares;

namespace UserOperationCaseStudy.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigurateCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
