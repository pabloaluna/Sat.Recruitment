using Sat.Recruitment.Core.Entities;

namespace Sat.Recruitment.Application.Dto
{
    public class UserDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public decimal Money { get; set; }

        public User ToEntity() => new User()
        {
            Name = this.Name,
            Email = this.Email,
            Address = this.Address,
            Phone = this.Phone,
            UserType = this.UserType,
            Money = this.Money,
        };        

        public static UserDto FromEntity(User user) => new UserDto()
        {
            Name = user.Name,
            Email = user.Email,
            Address = user.Address,
            Phone = user.Phone,
            UserType = user.UserType,
            Money = user.Money,
        };
    }
}
