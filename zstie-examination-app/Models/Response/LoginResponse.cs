using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.REST.Models.Response
{
    class LoginResponse
    {
        string token;
        string userId;
        string fullName;
        string className;

        public string Token { get => token; set => token = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string ClassName { get => className; set => className = value; }
        public string UserId { get => userId; set => userId = value; }
    }
}
