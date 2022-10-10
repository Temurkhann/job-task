using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<User> CreateAsync(UserForCreationDto dto);
        ValueTask<User> UpdateAsync(long id, UserForCreationDto dto);
        ValueTask<User> GetAsync(Expression<Func<User, bool>> expression);
        ValueTask<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
