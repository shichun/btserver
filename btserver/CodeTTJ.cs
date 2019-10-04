using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbCode
    {
        public string id;
        public int compid;
        public int departid;
        public string codetype;
        public string codekey;
        public int sort;
        public string valen;
        public string valcn;
        public string reserve1;
        public string reserve2;
        public string reserve3;
        public string reserve4;
        public string reserve5;
        public int status;
        public string createuser;
        public string createdate;
        public string updateuser;
        public string updatedate;

    }

    class CodeTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbCode container = new TbCode();
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
                    container.compid = convertInt(OneRow_Data[1]);
                    container.departid = convertInt(OneRow_Data[2]);
                    container.codetype = convertString(OneRow_Data[3]);
                    container.codekey = convertString(OneRow_Data[4]);
                    container.sort = convertInt(OneRow_Data[5]);
                    container.valen = convertString(OneRow_Data[6]);
                    container.valcn = convertString(OneRow_Data[7]);
                    container.reserve1 = convertString(OneRow_Data[8]);
                    container.reserve2 = convertString(OneRow_Data[9]);
                    container.reserve3 = convertString(OneRow_Data[10]);
                    container.reserve4 = convertString(OneRow_Data[11]);
                    container.reserve5 = convertString(OneRow_Data[12]);
                    container.status = convertInt(OneRow_Data[13]);
                    container.createuser = convertString(OneRow_Data[14]);
                    container.createdate = convertString(OneRow_Data[15]);
                    container.updateuser = convertString(OneRow_Data[16]);
                    container.updatedate = convertString(OneRow_Data[17]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbCode tbBom)
        {
            string jsonstr = JsonMapper.ToJson(tbBom);//把结构体各个变量转成Json格式的文本字符串
                                                      //JsonData B = JsonMapper.ToObject(A+'\n');
            Console.WriteLine("开始写入");
            char comma = ',';
            StringBuilder jsonStrBuilder = new StringBuilder(jsonstr);
            File_write(jsonStrBuilder.Append(comma).Append('\n').ToString(), path);
        }


    }
}
