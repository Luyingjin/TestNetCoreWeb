using MyNetCoreApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApi.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers(GetUsersInput input);
        UserDto GetUser(int id);
    }
}
