using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class ExamListItemModel
    {
        ExamUltraSimpleModel exam;
        QualificationModel qualification;
        int score;
        int maxScore;

        [JsonProperty(PropertyName = "score")]
        public int Score { get => score; set => score = value; }

        [JsonProperty(PropertyName = "maxScore")]
        public int MaxScore { get => maxScore; set => maxScore = value; }

        [JsonProperty(PropertyName = "exam")]
        internal ExamUltraSimpleModel Exam { get => exam; set => exam = value; }

        [JsonProperty(PropertyName = "qualification")]
        internal QualificationModel Qualification { get => qualification; set => qualification = value; }
    }
}
