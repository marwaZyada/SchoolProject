using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.DTO;
using School.Domain.Entities.Authentication;
using School.Domain.Repositories.Interfaces.Generic;
using School.Infrastructure.Migrations;
using School.Infrastructure.Service;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IEntityRepository<ApplicationUser> _entityRepository;
        private readonly IMapper _mapper;

        public AccountsController(ITokenService tokenService, IEntityRepository<ApplicationUser> entityRepository,
            IMapper mapper)
        {
            _tokenService = tokenService;
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(ApplicationUserDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var user = _mapper.Map<ApplicationUser>(model);
                await _entityRepository.Add(user);
                BackgroundJob.Schedule(() => Console.WriteLine("Wecome to school Application"), TimeSpan.FromSeconds(5));

                return Ok(new
                {
                    Email = user.Email,
                    Token = await _tokenService.CreateTokenAsync(user),
                });
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(ApplicationUserDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("auth", "Un autherized");
                    return BadRequest(ModelState);
                }

                var user = await _entityRepository.Get(u => u.UserName == model.UserName);
                if (user == null) return BadRequest("Not Authorized");
                else
                {
                    if (model.UserName != user.UserName || model.Password != user.Password) return BadRequest("Not Authorized");
                    return Ok(new
                    {
                        Email = user.Email,
                        Token = await _tokenService.CreateTokenAsync(user),
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
