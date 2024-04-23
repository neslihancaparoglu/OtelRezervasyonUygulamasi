using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<bool> CreateUserAsync(User user);
        Task<bool> CheckRoomAvailabilityAsync(UserDto user);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<User, bool>> expression);
        IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression);

    }
}
