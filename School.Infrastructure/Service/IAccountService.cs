using School.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Service
{
    public interface IAccountService
    {
        Task<bool> SignInAsync(ApplicationUser user,string username, string password);
        Task<bool> CreateAsync(ApplicationUser user, string password);
    }
}
