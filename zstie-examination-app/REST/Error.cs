using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.REST
{
    class Error
    {
        int errorCode;
        string developerMessage;

        public string DeveloperMessage { get => developerMessage; set => developerMessage = value; }
        public int ErrorCode { get => errorCode; set => errorCode = value; }
    }
}
