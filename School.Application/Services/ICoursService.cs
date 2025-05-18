using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Services
{
    public interface ICoursService
    {

      Task<string> Coursetitle(Course course) ;
    }
}
