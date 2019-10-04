using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbManufacturer
    {
        public string id;
        public string manufacturername;
        public int manufacturertype;
        public string address;
        public string handler;
        public string tell;
        public string fax;
        public string note;
        public int status;
        public int compid;
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

    class ManufacturerTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbManufacturer container = new TbManufacturer();
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
                    container.manufacturername = convertString(OneRow_Data[1]);
                    container.manufacturertype = convertInt(OneRow_Data[2]);
                    container.address = convertString(OneRow_Data[3]);
                    container.handler = convertString(OneRow_Data[4]);
                    container.tell = convertString(OneRow_Data[5]);
                    container.fax = convertString(OneRow_Data[6]);
                    container.note = convertString(OneRow_Data[7]);
                    container.status = convertInt(OneRow_Data[8]);
                    container.compid = convertInt(OneRow_Data[9]);
                    container.reserve1 = convertString(OneRow_Data[10]);
                    container.reserve2 = convertString(OneRow_Data[11]);
                    container.reserve3 = convertString(OneRow_Data[12]);
                    container.reserve4 = convertString(OneRow_Data[13]);
                    container.reserve5 = convertString(OneRow_Data[14]);
                    container.createuser = convertString(OneRow_Data[15]);
                    container.createdate = convertString(OneRow_Data[16]);
                    container.updateuser = convertString(OneRow_Data[17]);
                    container.updatedate = convertString(OneRow_Data[18]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbManufacturer tbBom)
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
