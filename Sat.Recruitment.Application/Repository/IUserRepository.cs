using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Repository
{
    public interface IUserRepository
    {
        string Create(User user);
        IEnumerable<User> GetAll();
        User? GetById(string id);
        User? GetBy(Expression<Func<User, bool>> predicate);
    }
}
