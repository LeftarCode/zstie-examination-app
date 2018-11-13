using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.DTO
{
    class RegisterUserDTO
    {
        String username;
        String fullName;
        String email;
        String password;
        String verificationCode;

        public string Username { get => username; set => username = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string VerificationCode { get => verificationCode; set => verificationCode = value; }

        public RegisterUserDTO(String username, String fullName, String email, String password, String verificationCode)
        {
            this.Username = username;
            this.FullName = fullName;
            this.Email = email;
            this.Password = password;
            this.VerificationCode = verificationCode;
        }
    }
}
