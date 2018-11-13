using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        INotifyChangeView notifyChangeView;
        INotifyProgressBarVisibility notifyProgressBarVisibility;
        INotifyMessageViewVisibility notifyMessageViewVisibility;

        internal INotifyChangeView NotifyChangeView { get => notifyChangeView; set => notifyChangeView = value; }
        internal INotifyProgressBarVisibility NotifyProgressBarVisibility { get => notifyProgressBarVisibility; set => notifyProgressBarVisibility = value; }
        internal INotifyMessageViewVisibility NotifyMessageViewVisibility { get => notifyMessageViewVisibility; set => notifyMessageViewVisibility = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
