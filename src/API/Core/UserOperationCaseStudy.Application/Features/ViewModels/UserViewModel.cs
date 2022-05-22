using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Application.Features.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
    }
}
