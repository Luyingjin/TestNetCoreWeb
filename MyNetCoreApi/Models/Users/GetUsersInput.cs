using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApi.Models.Users
{
    public class GetUsersInput: GetSearchBaseInput
    {
        public string Name { get; set; }
    }
}
