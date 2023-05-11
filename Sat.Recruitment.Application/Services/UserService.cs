using Mapster;
using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Application.Repository;
using Sat.Recruitment.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Create(UserDto user)
        {
            user.Email = EmailHelper.Normalize(user.Email);
            user.Money += CalculateGifByUserType(user.UserType, user.Money);

            var exist = _userRepository.GetBy(x => x.Name == user.Name && x.Email == user.Email && x.Address == user.Address && x.Phone == user.Phone);

            if (exist != null)
            {
                throw new Exception("User is duplicated");
            }

            _userRepository.Create(user.ToEntity());

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void UserFromFile(string fileName)
        {
            var path = Directory.GetCurrentDirectory() + fileName;

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line!.Split(',')[0].ToString(),
                    Email = line!.Split(',')[1].ToString(),
                    Phone = line!.Split(',')[2].ToString(),
                    Address = line!.Split(',')[3].ToString(),
                    UserType = line!.Split(',')[4].ToString(),
                    Money = decimal.Parse(line!.Split(',')[5].ToString()),
                };

                _userRepository.Adapt(user);
            }

            reader.Close();
        }

        private decimal CalculateGifByUserType(string userType, decimal money)
        {
            if (userType == "Normal")
            {
                if (money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = money * percentage;

                    return money + gif;
                }

                if (money < 100)
                {
                    if (money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = money * percentage;
                        
                        return money + gif;
                    }
                }
            }

            if (userType == "SuperUser")
            {
                if (money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = money * percentage;

                    return money + gif;
                }
            }

            if (userType == "Premium")
            {
                if (money > 100)
                {
                    var gif = money * 2;
                    return money + gif;
                }
            }

            return 0;
        }
    }
}
