using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.InMemoryStorage.Repository;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly UserRepository _userRepository;
        private readonly UserService _userService;
        private readonly UsersController _usersController;
        public UnitTest1()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
            _usersController = new UsersController(_userService);
        }

        [Fact]
        public void CreateUser()
        {
            var mockUser = new CreateUserDto()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };
            var result = _usersController.CreateUser(mockUser);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void CreateDuplicatedUser()
        {
            var mockUser = new CreateUserDto()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            _usersController.CreateUser(mockUser);
            var result = _usersController.CreateUser(mockUser);

            Assert.False(result.IsSuccess);
            Assert.Equal("User is duplicated", result.Errors);
        }
    }
}
