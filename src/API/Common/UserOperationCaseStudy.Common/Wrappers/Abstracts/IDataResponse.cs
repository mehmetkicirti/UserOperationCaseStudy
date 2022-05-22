using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Common.Wrappers.Abstracts
{
    public interface IDataResponse<T>: IResponse
    {
        T Data { get; set; }
    }
}
