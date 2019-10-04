using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbBom
    {
        public string id;
        public string nodename;
        public string nodesn;
        public string process;
        public string pic;
        public int sort;
        public int parentid;
        public int nodetype;
        public int compid;
        public int departid;
        public int standardqty;
        public int majorparts;
        public string partstype;
        public int warnnum;
        public string targetlifetime;
        public string maxlifetime;
        public string minlifetime;
        public string targetlifetimehrs;
        public string maxlifetimehrs;
        public string minlifetimehrs;
        public int stationnum;
        public string stationlist;
        public string note;
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

    class BomTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbBom container = new TbBom();
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
                    container.nodename = convertString(OneRow_Data[1]);
                    container.nodesn = convertString(OneRow_Data[2]);
                    container.process = convertString(OneRow_Data[3]);
                    container.pic = convertString(OneRow_Data[4]);
                    container.sort = convertInt(OneRow_Data[5]);
                    container.parentid = convertInt(OneRow_Data[6]);
                    container.nodetype = convertInt(OneRow_Data[7]);
                    container.compid = convertInt(OneRow_Data[8]);
                    container.departid = convertInt(OneRow_Data[9]);
                    container.standardqty = convertInt(OneRow_Data[10]);
                    container.majorparts = convertInt(OneRow_Data[11]);
                    container.partstype = convertString(OneRow_Data[12]);
                    container.warnnum = convertInt(OneRow_Data[13]);
                    container.targetlifetime = convertString(OneRow_Data[14]);
                    container.maxlifetime = convertString(OneRow_Data[15]);
                    container.minlifetime = convertString(OneRow_Data[16]);
                    container.targetlifetimehrs = convertString(OneRow_Data[17]);
                    container.maxlifetimehrs = convertString(OneRow_Data[18]);
                    container.minlifetimehrs = convertString(OneRow_Data[19]);
                    container.stationnum = convertInt(OneRow_Data[20]);
                    container.stationlist = convertString(OneRow_Data[21]);
                    container.note = convertString(OneRow_Data[22]);
                    container.status = convertInt(OneRow_Data[23]);
                    container.reserve1 = convertString(OneRow_Data[24]);
                    container.reserve2 = convertString(OneRow_Data[25]);
                    container.reserve3 = convertString(OneRow_Data[26]);
                    container.reserve4 = convertString(OneRow_Data[27]);
                    container.reserve5 = convertString(OneRow_Data[28]);
                    container.createuser = convertString(OneRow_Data[29]);
                    container.createdate = convertString(OneRow_Data[30]);
                    container.updateuser = convertString(OneRow_Data[31]);
                    container.updatedate = convertString(OneRow_Data[32]);
                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbBom tbBom)
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
