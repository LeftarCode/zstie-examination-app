using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class ExamUltraSimpleModel
    {
        string id;
        string startTime;
        string finishTime;
        bool isFinished;

        public string Id { get => id; set => id = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string FinishTime { get => finishTime; set => finishTime = value; }
        public bool IsFinished { get => isFinished; set => isFinished = value; }
    }
}
