using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSTIE.Models.DTO;
using ZSTIE.Models.Response;
using ZSTIE.REST;

namespace ZSTIE.Managers
{
    class ExamManager
    {
        public Response<ExamModel> CreateExam(int questionsCount, string professionCode, string userId)
        {
            IRestResponse response = REST.RestClient.Instance.CreateExam(questionsCount, professionCode, userId);
            Response<ExamModel> responseData = ResponseHelper.GetResponse<ExamModel>(response);

            return responseData;
        }

        public Response<ExamScore> SubmitExam(SubmitExamDTO submitExamDTO)
        {
            IRestResponse response = REST.RestClient.Instance.SubmitExam(submitExamDTO);
            Response<ExamScore> responseData = ResponseHelper.GetResponse<ExamScore>(response);

            return responseData;
        }

        public Response<FinishedExamModel> GetExamById(string id)
        {
            IRestResponse response = REST.RestClient.Instance.GetExamById(id);
            Response<FinishedExamModel> responseData = ResponseHelper.GetResponse<FinishedExamModel>(response);

            return responseData;
        }

        public Response<List<ExamListItemModel>> GetUserExams()
        {
            IRestResponse response = REST.RestClient.Instance.GetUserExams();
            Response<List<ExamListItemModel>> responseData = ResponseHelper.GetResponse<List<ExamListItemModel>>(response);

            return responseData;
        }

        public IRestResponse CreateQuestion(CreateQuestionDTO createQuestionDTO)
        {
            IRestResponse response = REST.RestClient.Instance.CreateQuestion(createQuestionDTO);

            return response;
        }
    }
}
