using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using ZSTIE.Properties;
using ZSTIE.REST.Models.Response;
using ZSTIE.ViewModels.Notifiers;
using ZSTIE.Views;

namespace ZSTIE.ViewModels
{
    class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged, INotifyRegisterClick, INotifyLoginSuccess, INotifyMessageViewVisibility, INotifyGoLoginView, INotifyProgressBarVisibility
    {
        private object selectedViewModel;
        private int contentBlurRadius = 0;
        private MessageView messageView;
        private CircularProgressBar progressBar;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public MessageView MessageView { get => messageView; set => messageView = value; }
        public int ContentBlurRadius
        {
            get => contentBlurRadius;
            set
            {
                contentBlurRadius = value;
                OnPropertyChanged("ContentBlurRadius");
            }
        }

        public CircularProgressBar ProgressBar { get => progressBar; set => progressBar = value; }

        public MainWindowViewModel(CircularProgressBar progressBar, MessageView messageView)
        {
            ProgressBar = progressBar;
            MessageView = messageView;

            SelectedViewModel = new LoginViewModel(this);

            OnLoginSuccess();
        }

        public void OnLoginSuccess()
        {
        }

        public void HideMessageView()
        {
            ContentBlurRadius = 0;

            MessageView.Visibility = Visibility.Hidden;
        }

        public void ShowMessageView(string title, string content)
        {
            ContentBlurRadius = 15;

            (MessageView.DataContext as MessageViewModel).Title = title;
            (MessageView.DataContext as MessageViewModel).Content = content;

            MessageView.Visibility = Visibility.Visible;
        }

        public void ShowProgressBar()
        {
            ContentBlurRadius = 15;
            progressBar.Visibility = Visibility.Visible;
        }

        public void HideProgressBar()
        {
            ContentBlurRadius = 0;
            progressBar.Visibility = Visibility.Hidden;
        }

        public void GoRegisterView()
        {
            SelectedViewModel = new RegisterViewModel();
            (SelectedViewModel as RegisterViewModel).NotifyMessageViewVisibility = this;
            (SelectedViewModel as RegisterViewModel).NotifyProgressBarVisibility = this;
        }

        public void OnRegisterClick()
        {
            GoRegisterView();
        }

        public void GoLoginView()
        {
            Settings.Default.AUTHENTICATION_TOKEN = "";
            Settings.Default.Save();
            SelectedViewModel = new LoginViewModel(this);
            (SelectedViewModel as LoginViewModel).NotifyMessageViewVisibility = this;
            (SelectedViewModel as LoginViewModel).NotifyProgressBarVisibility = this;
        }

        public void OnLoginSuccess(LoginResponse loginResponse)
        {
            SelectedViewModel = new GeneralViewModel(this, loginResponse);
        }
    }
}
