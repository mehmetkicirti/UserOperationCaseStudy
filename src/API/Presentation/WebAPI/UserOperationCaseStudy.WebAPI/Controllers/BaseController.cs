using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserOperationCaseStudy.WebAPI.Controllers
{
    public class BaseController:ControllerBase
    {
        protected readonly IMediator Mediator;
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
