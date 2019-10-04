using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    class RestfulRequester
    {
        public  void sendRequestUploadDB(string filePath)
        {
            filePath = "c:\\bt/tbuser.json";
            string contents = File.ReadAllText(filePath, Encoding.UTF8);
            StringBuilder jsonStrBuilder = new StringBuilder("[");
            string jsonContent= contents.Substring(0, contents.LastIndexOf(","));
            jsonStrBuilder.Append(jsonContent).Append("]");
        }
    }
}
