using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class FinishedExamQuestionModel
    {
        string imageUrl;
        int correctAnswerIndex;
        string content;
        List<string> answers;
        int selectedAnswer;

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }

        [JsonProperty(PropertyName = "correctAnswerIndex")]
        public int CorrectAnswerIndex { get => correctAnswerIndex; set => correctAnswerIndex = value; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get => content; set => content = value; }

        [JsonProperty(PropertyName = "answers")]
        public List<string> Answers { get => answers; set => answers = value; }

        [JsonProperty(PropertyName = "selectedAnswer")]
        public int SelectedAnswer { get => selectedAnswer; set => selectedAnswer = value; }
    }
}
