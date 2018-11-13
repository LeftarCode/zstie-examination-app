using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZSTIE.Models.DTO;
using ZSTIE.REST;
using ZSTIE.Utilities;

namespace ZSTIE.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        string username;
        string fullName;
        string email;
        string password;
        string verifyPassword;
        string verificationCode;

        public ICommand RegisterUser
        {
            get
            {
                return new RelayCommand(RegisterUserExecute, CanRegisterUserExecute);
            }
        }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string VerifyPassword
        {
            get => verifyPassword;
            set
            {
                verifyPassword = value;
                OnPropertyChanged("VerifyPassword");
            }
        }
        public string VerificationCode
        {
            get => verificationCode;
            set
            {
                verificationCode = value;
                OnPropertyChanged("VerificationCode");
            }
        }

        private void RegisterUserExecute()
        {
            if (password != verificationCode)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błędne hasła!", "Podane hasła są różne!");
                return;
            }

            RegisterUserDTO registerUserDTO = new RegisterUserDTO(username, fullName, email, password, verificationCode); 
            try
            {
            }
            catch (Exception e)
            {
                NotifyMessageViewVisibility.ShowMessageView("Nieoczekiwany błąd!", e.Message);
            }
        }

        private bool CanRegisterUserExecute()
        {
            return true;
        }
    }
}
