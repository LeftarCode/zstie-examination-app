using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class MessageViewModel : ViewModelBase
    {
        string content;
        string title;
        INotifyMessageViewVisibility notifyMessageViewHide;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new RelayCommand(Close, CanClose);
            }
        }

        internal INotifyMessageViewVisibility NotifyMessageViewVisibility { get => notifyMessageViewHide; set => notifyMessageViewHide = value; }

        public virtual void Close()
        {
            NotifyMessageViewVisibility.HideMessageView();
        }

        public virtual bool CanClose()
        {
            return true;
        }
    }
}
