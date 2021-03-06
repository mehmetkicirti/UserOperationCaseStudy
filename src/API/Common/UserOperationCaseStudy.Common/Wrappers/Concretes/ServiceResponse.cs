using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Common.Wrappers.Concretes
{
    public class ServiceResponse : IResponse
    {
        public ServiceResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public ServiceResponse(string message):this(true)
        {
            Message = message;
        }

        public ServiceResponse(string message, bool isSuccess) : this(isSuccess)
        {
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
