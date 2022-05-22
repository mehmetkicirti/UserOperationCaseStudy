using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Common.Wrappers.Concretes
{
    public class DataResponse<T> : ServiceResponse, IDataResponse<T>
    {
        public DataResponse() : base(true)
        {
        }

        public DataResponse(string message) : base(true, message)
        {
        }

        public DataResponse(string message, T data) : base(true, message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
