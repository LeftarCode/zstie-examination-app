using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class QuestionModel
    {
        string id;
        string question;
        List<string> answers;
        string imageUrl;

        public string Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public List<string> Answers { get => answers; set => answers = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
    }
}
