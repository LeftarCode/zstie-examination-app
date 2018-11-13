using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class QualificationModel
    {
        string code;
        string pictureUrl;

        public string Code { get => code; set => code = value; }
        public string PictureUrl { get => pictureUrl; set => pictureUrl = value; }
    }
}
