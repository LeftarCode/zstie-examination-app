using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using ZSTIE.Models.Response;
using ZSTIE.Properties;
using ZSTIE.REST.Models.Response;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class GeneralViewModel : ViewModelBase, INotifyChangeView
    {
        private object currentViewModel;
        private INotifyGoLoginView notifyGoLoginView;
        private string userName;
        private Stack<ViewModelBase> viewStack = new Stack<ViewModelBase>();

        public object CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public ICommand GoLoginView
        {
            get
            {
                return new RelayCommand(GoLoginViewExecute, CanGoLoginViewExecute);
            }
        }

        public ICommand Backward
        {
            get
            {
                return new RelayCommand(BackwardExecute, CanBackwardExecute);
            }
        }

        internal INotifyGoLoginView NotifyGoLoginView { get => notifyGoLoginView; set => notifyGoLoginView = value; }
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public void ChangeView(ViewModelBase viewModelBase)
        {
            viewStack.Push(CurrentViewModel as ViewModelBase);

            CurrentViewModel = viewModelBase;
            (CurrentViewModel as ViewModelBase).NotifyChangeView = this;
            (CurrentViewModel as ViewModelBase).NotifyProgressBarVisibility = NotifyProgressBarVisibility;
            (CurrentViewModel as ViewModelBase).NotifyMessageViewVisibility = NotifyMessageViewVisibility;
        }

        public GeneralViewModel(MainWindowViewModel mainWindowViewModel, LoginResponse loginResponse)
        {
            NotifyProgressBarVisibility = mainWindowViewModel;
            NotifyMessageViewVisibility = mainWindowViewModel;
            NotifyGoLoginView = mainWindowViewModel;

            Settings.Default.AUTHENTICATION_TOKEN = loginResponse.Token;
            Settings.Default.USER_ID = loginResponse.UserId;
            Settings.Default.Save();

            UserName = loginResponse.FullName + " - " + loginResponse.ClassName;

            ChangeView(new MenuViewModel());
        }

        private void BackwardExecute()
        {
            if(viewStack.Count > 1)
            {
                CurrentViewModel = viewStack.Pop();
                (CurrentViewModel as ViewModelBase).NotifyChangeView = this;
                (CurrentViewModel as ViewModelBase).NotifyProgressBarVisibility = NotifyProgressBarVisibility;
                (CurrentViewModel as ViewModelBase).NotifyMessageViewVisibility = NotifyMessageViewVisibility;
            }
        }

        private bool CanBackwardExecute()
        {
            return true;
        }

        public void GoLoginViewExecute()
        {
            NotifyGoLoginView.GoLoginView();
        }

        public bool CanGoLoginViewExecute()
        {
            return true;
        }
    }
}
