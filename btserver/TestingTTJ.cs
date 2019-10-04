using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbTesting
    {
        public string id;
        public int maintenancetypeid;
        public string kitssn;
        public string equipmenttype;
        public string kitstype;
        public string rrlotid;
        public string reasoncode;
        public string remark;
        public int kitsresult;
        public int testingstatus;
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

    class TestingTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbTesting container = new TbTesting();
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
                    container.maintenancetypeid = convertInt(OneRow_Data[1]);
                    container.kitssn = convertString(OneRow_Data[2]);
                    container.equipmenttype = convertString(OneRow_Data[3]);
                    container.kitstype = convertString(OneRow_Data[4]);
                    container.rrlotid = convertString(OneRow_Data[5]);
                    container.reasoncode = convertString(OneRow_Data[6]);
                    container.remark = convertString(OneRow_Data[7]);
                    container.kitsresult = convertInt(OneRow_Data[8]);
                    container.testingstatus = convertInt(OneRow_Data[9]);
                    container.compid = convertInt(OneRow_Data[10]);
                    container.departid = convertInt(OneRow_Data[11]);
                    container.status = convertInt(OneRow_Data[12]);
                    container.reserve1 = convertString(OneRow_Data[13]);
                    container.reserve2 = convertString(OneRow_Data[14]);
                    container.reserve3 = convertString(OneRow_Data[15]);
                    container.reserve4 = convertString(OneRow_Data[16]);
                    container.reserve5 = convertString(OneRow_Data[17]);
                    container.createuser = convertString(OneRow_Data[18]);
                    container.createdate = convertString(OneRow_Data[19]);
                    container.updateuser = convertString(OneRow_Data[20]);
                    container.updatedate = convertString(OneRow_Data[21]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbTesting tbBom)
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
