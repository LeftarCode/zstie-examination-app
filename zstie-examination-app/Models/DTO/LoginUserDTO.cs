using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.REST.Models.DTO
{
    class LoginUserDTO
    {
        String username;
        String password;

        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }

        public LoginUserDTO()
        {

        }

        public LoginUserDTO(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
