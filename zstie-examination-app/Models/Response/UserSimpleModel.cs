using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.Models.Response
{
    class UserSimpleModel
    {
        string id;
        string fullName;

        public string Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
    }
}
