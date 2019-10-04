using LitJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbFaultCode
    {
        public string id;
        public string faultcode;
        public string faultname;
        public string compid;
        public string departid;
        public string note;
        public string status;
        public string reserve1;
        public string reserve2;
        public string reserve3;
        public string reserve4;
        public string reserve5;
        public string createuser;
        public string createdate;
        public string updateuser;
        public string updatedate;

    }

    class FaultCodeTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbFaultCode container = new TbFaultCode();
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string lineString = line.ToString();
                string[] OneRow_Data = lineString.Split(';');
                if (OneRow_Data.Length > 0)
                {
                    container.id = convertString(OneRow_Data[0]);
                    if (container.id.Equals(""))
                    {
                        continue;
                    }

                    container.faultcode = convertString(OneRow_Data[1]);
                    container.faultname = convertString(OneRow_Data[2]);
                    container.compid = convertString(OneRow_Data[3]);
                    container.departid = convertString(OneRow_Data[4]);
                    container.note = convertString(OneRow_Data[5]);
                    container.status = convertString(OneRow_Data[6]);
                    container.reserve1 = convertString(OneRow_Data[7]);
                    container.reserve2 = convertString(OneRow_Data[8]);
                    container.reserve3 = convertString(OneRow_Data[9]);
                    container.reserve4 = convertString(OneRow_Data[10]);
                    container.reserve5 = convertString(OneRow_Data[11]);
                    container.createuser = convertString(OneRow_Data[12]);
                    container.createdate = convertString(OneRow_Data[13]);
                    container.updateuser = convertString(OneRow_Data[14]);
                    container.updatedate = convertString(OneRow_Data[15]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbFaultCode entity)
        {
            string jsonstr = JsonConvert.SerializeObject(entity);//把结构体各个变量转成Json格式的文本字符串
            Console.WriteLine("开始写入");
            char comma = ',';
            StringBuilder jsonStrBuilder = new StringBuilder(jsonstr);
            File_write(jsonStrBuilder.Append(comma).Append('\n').ToString(), path);
        }


    }
}
