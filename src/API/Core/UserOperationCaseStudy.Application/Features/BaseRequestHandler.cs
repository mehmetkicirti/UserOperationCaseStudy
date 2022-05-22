using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Domain.Abstract;
using UserOperationCaseStudy.Common.Repository;

namespace UserOperationCaseStudy.Application.Features
{
    public class BaseRequestHandler<TRepository, T>
        where TRepository: IGenericRepository<T>
        where T: BaseEntity
    {
        protected readonly TRepository iRepository;
        protected readonly IMapper iMapper;
        public BaseRequestHandler(TRepository repository, IMapper mapper)
        {
            iRepository = repository;
            iMapper = mapper;
        }
    }
}
