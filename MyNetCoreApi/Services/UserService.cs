using MyNetCoreApi.IServices;
using MyNetCoreApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApi.Services
{
    public class UserService : IUserService
    {
        List<UserDto> users = new List<UserDto>();
       public UserService() {
            for (int i = 1; i <= 25; i++)
            {
                users.Add(new UserDto { Id = i, Age = i+10, Gender = "女", Name = $"女孩{i}" });
            }
           
        }
        public UserDto GetUser(int id)
        {
            return users.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<UserDto> GetUsers(GetUsersInput input)
        {
            var query = users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(input.Name))
                query = query.Where(m => m.Name.Contains(input.Name));
            var list = query.OrderBy(m=>m.Id).Skip(input.PageIndex * input.PageSize).Take(input.PageSize).ToList();
            return list;
        }
    }
}
