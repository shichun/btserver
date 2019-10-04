using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbMajorPartsLog
    {
        public string id;
        public int logtype;
        public int equipmentid;
        public int kitsid;
        public string equipmenttype;
        public string kitstype;
        public string kitssn;
        public string partstype;
        public string partssn;
        public string partsname;
        public string process;
        public string batchno;
        public string productdate;
        public string expiredate;
        public string note;
        public int lifetimewfr;
        public int lifetimehrs;
        public int targetlifetimehrs;
        public int targetlifetime;
        public int partstimes;
        public int stationnum;
        public string stationlist;
        public string location;
        public int partsstatus;
        public string reasoncode;
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

    class MajorPartsLogTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbMajorPartsLog container = new TbMajorPartsLog();
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
                    container.logtype = convertInt(OneRow_Data[1]);
                    container.equipmentid = convertInt(OneRow_Data[2]);
                    container.kitsid = convertInt(OneRow_Data[3]);
                    container.equipmenttype = convertString(OneRow_Data[4]);
                    container.kitstype = convertString(OneRow_Data[5]);
                    container.kitssn = convertString(OneRow_Data[6]);
                    container.partstype = convertString(OneRow_Data[7]);
                    container.partssn = convertString(OneRow_Data[8]);
                    container.partsname = convertString(OneRow_Data[9]);
                    container.process = convertString(OneRow_Data[10]);
                    container.batchno = convertString(OneRow_Data[11]);
                    container.productdate = convertString(OneRow_Data[12]);
                    container.expiredate = convertString(OneRow_Data[13]);
                    container.note = convertString(OneRow_Data[14]);
                    container.lifetimewfr = convertInt(OneRow_Data[15]);
                    container.lifetimehrs = convertInt(OneRow_Data[16]);
                    container.targetlifetimehrs = convertInt(OneRow_Data[17]);
                    container.targetlifetime = convertInt(OneRow_Data[18]);
                    container.partstimes = convertInt(OneRow_Data[19]);
                    container.stationnum = convertInt(OneRow_Data[20]);
                    container.stationlist = convertString(OneRow_Data[21]);
                    container.location = convertString(OneRow_Data[22]);
                    container.partsstatus = convertInt(OneRow_Data[23]);
                    container.reasoncode = convertString(OneRow_Data[24]);
                    container.compid = convertInt(OneRow_Data[25]);
                    container.departid = convertInt(OneRow_Data[26]);
                    container.status = convertInt(OneRow_Data[27]);
                    container.reserve1 = convertString(OneRow_Data[28]);
                    container.reserve2 = convertString(OneRow_Data[29]);
                    container.reserve3 = convertString(OneRow_Data[30]);
                    container.reserve4 = convertString(OneRow_Data[31]);
                    container.reserve5 = convertString(OneRow_Data[32]);
                    container.createuser = convertString(OneRow_Data[33]);
                    container.createdate = convertString(OneRow_Data[34]);
                    container.updateuser = convertString(OneRow_Data[35]);
                    container.updatedate = convertString(OneRow_Data[36]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbMajorPartsLog tbBom)
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
