using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbTestingVal
    {
        public string id;
        public int testingtypeid;
        public int testparamid;
        public string paramname;
        public string title1val;
        public string title2val;
        public string title3val;
        public string title4val;
        public string title5val;
        public string valmin;
        public string valmax;
        public string unit;
        public int compid;
        public int departid;
        public int status;
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

    class TestingValTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbTestingVal container = new TbTestingVal();
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
                    container.testingtypeid = convertInt(OneRow_Data[1]);
                    container.testparamid = convertInt(OneRow_Data[2]);
                    container.paramname = convertString(OneRow_Data[3]);
                    container.title1val = convertString(OneRow_Data[4]);
                    container.title2val = convertString(OneRow_Data[5]);
                    container.title3val = convertString(OneRow_Data[6]);
                    container.title4val = convertString(OneRow_Data[7]);
                    container.title5val = convertString(OneRow_Data[8]);
                    container.valmin = convertString(OneRow_Data[9]);
                    container.valmax = convertString(OneRow_Data[10]);
                    container.unit = convertString(OneRow_Data[11]);
                    container.compid = convertInt(OneRow_Data[12]);
                    container.departid = convertInt(OneRow_Data[13]);
                    container.status = convertInt(OneRow_Data[14]);
                    container.reserve1 = convertString(OneRow_Data[15]);
                    container.reserve2 = convertString(OneRow_Data[16]);
                    container.reserve3 = convertString(OneRow_Data[17]);
                    container.reserve4 = convertString(OneRow_Data[18]);
                    container.reserve5 = convertString(OneRow_Data[19]);
                    container.createuser = convertString(OneRow_Data[20]);
                    container.createdate = convertString(OneRow_Data[21]);
                    container.updateuser = convertString(OneRow_Data[22]);
                    container.updatedate = convertString(OneRow_Data[23]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbTestingVal tbBom)
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
