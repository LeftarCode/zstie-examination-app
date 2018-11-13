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
    class NewExamManager
    {
        public Response<List<QualificationModel>> GetActiveExam()
        {
            IRestResponse response = REST.RestClient.Instance.GetActiveExam();
            Response<List<QualificationModel>> responseData = ResponseHelper.GetResponse<List<QualificationModel>>(response);

            return responseData;
        }
    }
}
