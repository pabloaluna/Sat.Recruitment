using Sat.Recruitment.Application.Repository;
using Sat.Recruitment.Core.Entities;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Sat.Recruitment.InMemoryStorage.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
        }
        public string Create(User user)
        {
            var id = Guid.NewGuid().ToString();

            user.Id = id;
            _users.Add(user);

            return id;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User? GetBy(Expression<Func<User, bool>> predicate)
        {
            return _users.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public User? GetById(string id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
