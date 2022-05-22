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

        public DataResponse(string message) : base(message, true )
        {
        }

        public DataResponse(T data) : base(true)
        {
            Data = data;
        }

        public DataResponse(string message, T data) : base(message, true)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
