using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.REST;

namespace ZSTIE.REST
{
    static class ResponseHelper
    {
        public static Response<T> GetResponse<T>(this IRestResponse restResponse)
        {
            var response = new Response<T>();

            response.StatusCode = restResponse.StatusCode;
            if (restResponse.StatusCode == HttpStatusCode.OK ||
                restResponse.StatusCode == HttpStatusCode.Created)
            {
                response.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
            }
            else
            {
                response.Error = JsonConvert.DeserializeObject<Error>(restResponse.Content);
            }

            return response;
        }
    }
}
