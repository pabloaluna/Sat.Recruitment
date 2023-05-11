using Sat.Recruitment.Api.Validators;
using Sat.Recruitment.Application.Dto;

namespace Sat.Recruitment.Api.Dto
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Money { get; set; }

        public UserDto ToDomain() => new UserDto { Name = Name, Email = Email, Address = Address, Phone = Phone, UserType = UserType };
    }
}
