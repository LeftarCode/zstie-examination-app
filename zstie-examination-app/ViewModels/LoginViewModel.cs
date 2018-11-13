using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZSTIE.Utilities;
using ZSTIE.REST;
using ZSTIE.REST.Models.Response;
using ZSTIE.Managers;
using System.Net;
using ZSTIE.REST.Models.DTO;
using ZSTIE.ViewModels.Notifiers;
using ZSTIE.Properties;

namespace ZSTIE.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        string username;
        string password;

        UserManager userManager = new UserManager();

        private INotifyLoginSuccess notifyLoginSuccess;
        private INotifyRegisterClick notifyRegisterClick;
        public ICommand LoginUser
        {
            get
            {
                return new RelayCommand(LoginUserExecute, CanLoginUserExecute);
            }
        }

        public ICommand RegisterUser
        {
            get
            {
                return new RelayCommand(RegisterUserExecute, CanRegisterUserExecute);
            }
        }

        public string Password {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Username {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        
        internal INotifyLoginSuccess NotifyLoginSuccess { get => notifyLoginSuccess; set => notifyLoginSuccess = value; }
        internal INotifyRegisterClick NotifyRegisterClick { get => notifyRegisterClick; set => notifyRegisterClick = value; }

        public LoginViewModel(MainWindowViewModel mainWindow)
        {
            NotifyLoginSuccess = mainWindow;
            NotifyMessageViewVisibility = mainWindow;
            NotifyRegisterClick = mainWindow;
        }

        private void LoginUserExecute()
        {
            LoginUserDTO loginUserDTO = new LoginUserDTO(username, password);
            
            try
            {
                Response<LoginResponse> response = userManager.LoginUser(loginUserDTO);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        NotifyLoginSuccess.OnLoginSuccess(response.Data);
                        break;
                    case HttpStatusCode.NotFound:
                        NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Nie znaleziona użytkownika o podanej nazwie");
                        break;
                    case HttpStatusCode.Unauthorized:
                        NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Podano błędne hasło!");
                        break;
                    case HttpStatusCode.InternalServerError:
                        NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Nieznany błąd serwera!");
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool CanLoginUserExecute()
        {
            return true;
        }

        private void RegisterUserExecute()
        {
            NotifyRegisterClick.OnRegisterClick();
        }

        private bool CanRegisterUserExecute()
        {
            return true;
        }
    }
}
