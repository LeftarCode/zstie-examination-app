using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.REST.Models.Response;

namespace ZSTIE.ViewModels.Notifiers
{
    interface INotifyLoginSuccess
    {
        void OnLoginSuccess(LoginResponse loginResponse);
    }
}
