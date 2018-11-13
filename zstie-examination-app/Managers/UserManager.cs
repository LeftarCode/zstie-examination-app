using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.REST;
using ZSTIE.REST.Models.Response;
using ZSTIE.REST.Models.DTO;
using RestSharp;
using ZSTIE.Models.Response;

namespace ZSTIE.Managers
{
    class UserManager
    {
        public Response<LoginResponse> LoginUser(LoginUserDTO loginUserDTO)
        {
            IRestResponse response = REST.RestClient.Instance.LoginUser(loginUserDTO);
            Response<LoginResponse> responseData = ResponseHelper.GetResponse<LoginResponse>(response);

            return responseData;
        }
        
        public Response<List<UserSimpleModel>> GetAllClassUsers(string className)
        {
            IRestResponse response = REST.RestClient.Instance.GetAllClassUsers(className);
            Response<List<UserSimpleModel>> responseData = ResponseHelper.GetResponse<List<UserSimpleModel>>(response);

            return responseData;
        }

        public Response<List<ClassSimpleModel>> GetAllClasses()
        {
            IRestResponse response = REST.RestClient.Instance.GetAllClasses();
            Response<List<ClassSimpleModel>> responseData = ResponseHelper.GetResponse<List<ClassSimpleModel>>(response);

            return responseData;
        }

        public Response<List<VerificationCodeSimpleModel>> GetRandomVerificationCode(List<string> className)
        {
            IRestResponse response = REST.RestClient.Instance.GetRandomVerificationCode(className);
            Response<List<VerificationCodeSimpleModel>> responseData = ResponseHelper.GetResponse<List<VerificationCodeSimpleModel>>(response);

            return responseData;
        }
    }
}
