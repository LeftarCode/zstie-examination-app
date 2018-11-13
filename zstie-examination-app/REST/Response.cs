using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.REST
{
    class Response<T>
    {
        public T Data { get; set; }
        public Error Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
