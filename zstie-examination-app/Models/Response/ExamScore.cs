using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class ExamScore
    {
        List<bool> answersCorrectness;
        int score;
        string id;

        public int Score { get => score; set => score = value; }
        public List<bool> AnswersCorrectness { get => answersCorrectness; set => answersCorrectness = value; }
        public string Id { get => id; set => id = value; }
    }
}
