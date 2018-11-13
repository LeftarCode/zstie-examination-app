using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class FinishedExamModel
    {
        string id;
        List<FinishedExamQuestionModel> questions;

        [JsonProperty(PropertyName = "id")]
        public string Id { get => id; set => id = value; }

        [JsonProperty(PropertyName = "questions")]
        internal List<FinishedExamQuestionModel> Questions { get => questions; set => questions = value; }
    }
}
