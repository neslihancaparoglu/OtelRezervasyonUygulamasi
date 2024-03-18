
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        List<UserForRegistrationDto> GetAllUsers();
        UserForRegistrationDto GetUserById(string id);
        UserForRegistrationDto CreateUser(UserForRegistrationDto userDto);
        void UpdateUser(UserForRegistrationDto userDto);
        void DeleteUser(string id);
    }
}
