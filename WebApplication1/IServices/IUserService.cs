using WebApplication1.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers(GetUsersInput input);
        UserDto GetUser(int id);
    }
}
