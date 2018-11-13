using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.DTO
{
    class CreateQuestionDTO
    {
        string professionCode;
        List<string> answers = new List<string>();
        string imageUrl;
        string question;
        int correctAnswerIndex;

        public List<string> Answers { get => answers; set => answers = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string Question { get => question; set => question = value; }
        public int CorrectAnswerIndex { get => correctAnswerIndex; set => correctAnswerIndex = value; }
        public string ProfessionCode { get => professionCode; set => professionCode = value; }
    }
}
