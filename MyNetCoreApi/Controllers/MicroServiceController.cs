using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreApi.IServices;
using MyNetCoreApi.Models.Users;
using MyNetCoreApi.Services;

namespace MyNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicroServiceController : ControllerBase
    {
        private readonly IUserService userService=null;
        public MicroServiceController()
        {
            userService = new UserService();
        }
        // GET: api/MicroService
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            GetUsersInput input = new GetUsersInput();
            foreach(var key in Request.Query.Keys)
            {
                switch (key)
                {
                    case "PageIndex":
                        var index = 0;
                        int.TryParse(Request.Query[key].ToString(), out index);
                        input.PageIndex = index;
                        break;
                    case "PageSize":
                        var size = 0;
                        int.TryParse(Request.Query[key].ToString(), out size);
                        input.PageSize = size;
                        break;
                    case "Sort":
                        var sortArray = Request.Query[key].ToString().Split(',');
                        
                        break;
                    case "Order":
                        var order = Request.Query[key].ToString();

                        break;
                    default:
                        foreach(var prop in input.GetType().GetProperties())
                        {
                            if (prop.Name.ToLower()== key.ToLower())
                            {
                                prop.SetValue(input, Request.Query[key].ToString());
                            }
                        }
                        break;
                }
            }

            return userService.GetUsers(input);
        }

        // GET: api/MicroService/5
        [HttpGet("{id}", Name = "Get")]
        public UserDto Get(int id)
        {
            return userService.GetUser(id);
        }

        // POST: api/MicroService
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MicroService/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
