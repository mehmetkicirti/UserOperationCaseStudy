using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Features.Users.Commands.CreateUser;
using UserOperationCaseStudy.Application.Features.Users.Commands.UpdateUser;
using UserOperationCaseStudy.Application.Features.ViewModels;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Application.Features.Users.Mapping
{
    public class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
