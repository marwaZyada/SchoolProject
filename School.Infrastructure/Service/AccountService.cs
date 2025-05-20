using Microsoft.AspNetCore.Http.HttpResults;
using School.Domain.Entities.Authentication;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IEntityRepository<ApplicationUser> _entityRepository;

        public AccountService(IEntityRepository<ApplicationUser> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<bool> CreateAsync(ApplicationUser user, string password)
        {
            await _entityRepository.Add(user);
            return true;
        }

        public async Task<bool> SignInAsync(ApplicationUser user, string username, string password)
        {
            var model = await _entityRepository.Get(u => u.UserName == user.UserName);
            if (model == null) return false;
            
                if (user.UserName != model.UserName || user.Password != model.Password) 
                    return false;
            return true;
        }
    }
}
