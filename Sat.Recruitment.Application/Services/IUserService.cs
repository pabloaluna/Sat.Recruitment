using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
    public interface IUserService
    {
        bool Create(UserDto user);
        IEnumerable<User> GetAll();
        void UserFromFile(string fileName);
    }
}
