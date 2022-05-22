using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Domain.Abstract;

namespace UserOperationCaseStudy.Domain.Entities
{
    public class User: BaseEntity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
