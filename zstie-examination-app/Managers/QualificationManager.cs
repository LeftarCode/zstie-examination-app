using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.Models.Response;
using ZSTIE.REST;

namespace ZSTIE.Managers
{
    class QualificationManager
    {
        public Response<List<QualificationModel>> GetAllQualifications()
        {
            IRestResponse response = REST.RestClient.Instance.GetAllQualifications();
            Response<List<QualificationModel>> responseData = ResponseHelper.GetResponse<List<QualificationModel>>(response);

            return responseData;
        }
    }
}
