using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.ViewModels.Notifiers
{
    interface INotifyMessageViewVisibility
    {
        void HideMessageView();
        void ShowMessageView(string title, string content);
    }
}
