using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Validators;
using Sat.Recruitment.Application.Services;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/create-user")]
        public ResultDto CreateUser([FromBody] CreateUserDto user)
        {
            var errors = "";
            if (!UserValidator.IsValid(user, out errors))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Errors = errors
                };
            }

            try
            {
                _userService.Create(user.ToDomain());
            } catch (Exception ex)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }

            return new ResultDto()
            {
                IsSuccess = true,
                Errors = "User Created"
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }
    }
}
