using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.REST.Models.Response;
using ZSTIE.REST.Models.DTO;
using System.Net;
using Newtonsoft.Json;
using ZSTIE.Properties;
using ZSTIE.Models.DTO;
using RestSharp.Serializers.Newtonsoft.Json;
using SimpleJson;

namespace ZSTIE.REST
{
    class RestClient
    {
        private static RestClient instance;
        private static RestSharp.RestClient client;

        public static RestClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestClient();
                }
                return instance;
            }
        }

        private RestClient()
        {
            client = new RestSharp.RestClient(Settings.Default.CONNECTION_STRING);
            client.Timeout = 20 * 1000;
        }

        private RestSharp.IRestResponse Execute(RestSharp.RestRequest restRequest)
        {
            var token = Settings.Default.AUTHENTICATION_TOKEN;
            restRequest.AddParameter("Authorization", "bearer " + token, RestSharp.ParameterType.HttpHeader);

            RestSharp.IRestResponse response = client.Execute(restRequest);

            if(response.ResponseStatus != RestSharp.ResponseStatus.Completed)
            {
                throw new Exception(response.ErrorMessage);
            }

            return response;
        }

        public RestSharp.IRestResponse LoginUser(LoginUserDTO loginUserDTO)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("login", RestSharp.Method.POST);
            request.AddParameter("username", loginUserDTO.Username);
            request.AddParameter("password", loginUserDTO.Password);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse GetAllClasses()
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("/admin/classes", RestSharp.Method.GET);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse GetAllQualifications()
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("qualifications", RestSharp.Method.GET);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }
        
        public RestSharp.IRestResponse GetRandomVerificationCode(List<string> classNames)
        {
            JsonObject json = new JsonObject();

            JsonArray arr = new JsonArray();

            foreach (var kvp in classNames)
            {
                arr.Add(kvp);
            }

            json.Add("classNames", arr);

            RestSharp.RestRequest request = new RestSharp.RestRequest("verificationcode", RestSharp.Method.POST);
            request.AddJsonBody(json);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse CreateQuestion(CreateQuestionDTO createQuestionDTO)
        {
            JsonObject json = new JsonObject();
            json.Add("professionCode", createQuestionDTO.ProfessionCode);
            json.Add("imageUrl", createQuestionDTO.ImageUrl);
            json.Add("correctAnswerIndex", createQuestionDTO.CorrectAnswerIndex);
            json.Add("content", createQuestionDTO.Question);

            JsonArray answers = new JsonArray();
            foreach( var answer in createQuestionDTO.Answers )
            {
                answers.Add(answer);
            }

            json.Add("answers", answers);

            RestSharp.RestRequest request = new RestSharp.RestRequest("question", RestSharp.Method.POST);
            request.AddJsonBody(json);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse GetActiveExam()
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("exams", RestSharp.Method.GET);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse GetAllClassUsers(string className)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("/admin/" + className + "/users" , RestSharp.Method.GET);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse CreateExam(int questionCount, string professionCode, string userId)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("/questions/" + userId, RestSharp.Method.GET);

            request.AddQueryParameter("professionCode", professionCode);
            request.AddQueryParameter("count", "" + questionCount);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse SubmitExam(SubmitExamDTO submitExamDTO)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("exam", RestSharp.Method.PUT);
            request.JsonSerializer = new NewtonsoftJsonSerializer();
            request.AddJsonBody(submitExamDTO);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse GetExamById(string id)
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("/exam/{id}", RestSharp.Method.GET);
            request.JsonSerializer = new NewtonsoftJsonSerializer();
            request.AddParameter("id", id, RestSharp.ParameterType.UrlSegment);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }

        public RestSharp.IRestResponse GetUserExams()
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest("/user/my/exam", RestSharp.Method.GET);

            RestSharp.IRestResponse response = Execute(request);

            return response;
        }
    }
}
