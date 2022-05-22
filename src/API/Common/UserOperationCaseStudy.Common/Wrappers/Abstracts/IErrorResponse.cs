using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Common.Wrappers.Abstracts
{
    public interface IErrorResponse : IResponse
    {
        int StatusCode { get; set; }
    }
}
