using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class ExamModel
    {
        List<QuestionModel> questions;
        
        public List<QuestionModel> Questions { get => questions; set => questions = value; }
    }
}
