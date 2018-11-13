using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.DTO
{
    class SubmitExamDTO
    {
        string userCode;
        List<string> questionsId;
        List<int> answersIndices;

        [JsonProperty(PropertyName = "userCode")]
        public string UserCode { get => userCode; set => userCode = value; }

        [JsonProperty(PropertyName = "questionsId")]
        public List<string> QuestionsId { get => questionsId; set => questionsId = value; }

        [JsonProperty(PropertyName = "answersIndices")]
        public List<int> AnswersIndices { get => answersIndices; set => answersIndices = value; }

        public SubmitExamDTO()
        {
            questionsId = new List<string>();
            answersIndices = new List<int>();
        }
    }
}
