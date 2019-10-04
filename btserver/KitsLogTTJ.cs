using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbKitsLog
    {
        public string id;
        public int logtype;
        public int operateid;
        public int equipmentid;
        public string kitssn;
        public string equipmenttype;
        public string kitstype;
        public int maintenancetypeid;
        public int pmcounterwfrs;
        public int pmcounterhrs;
        public int carrierlifehrs;
        public int carrierlifewfrs;
        public int headlifewfrs;
        public int headlifehrs;
        public int membranelifewfrs;
        public int membranelifehrs;
        public int retaininglifewfrs;
        public int retaininglifehrs;
        public string location;
        public int stationnum;
        public string stationlist;
        public string faultcode;
        public int kitsresult;
        public string reason;
        public string remark;
        public string workcontent;
        public string beforejson;
        public string afterjson;
        public int compid;
        public int departid;
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

    class KitsLogTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbKitsLog container = new TbKitsLog();
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
                    container.operateid = convertInt(OneRow_Data[2]);
                    container.equipmentid = convertInt(OneRow_Data[3]);
                    container.kitssn = convertString(OneRow_Data[4]);
                    container.equipmenttype = convertString(OneRow_Data[5]);
                    container.kitstype = convertString(OneRow_Data[6]);
                    container.maintenancetypeid = convertInt(OneRow_Data[7]);
                    container.pmcounterwfrs = convertInt(OneRow_Data[8]);
                    container.pmcounterhrs = convertInt(OneRow_Data[9]);
                    container.carrierlifehrs = convertInt(OneRow_Data[10]);
                    container.carrierlifewfrs = convertInt(OneRow_Data[11]);
                    container.headlifewfrs = convertInt(OneRow_Data[12]);
                    container.headlifehrs = convertInt(OneRow_Data[13]);
                    container.membranelifewfrs = convertInt(OneRow_Data[14]);
                    container.membranelifehrs = convertInt(OneRow_Data[15]);
                    container.retaininglifewfrs = convertInt(OneRow_Data[16]);
                    container.retaininglifehrs = convertInt(OneRow_Data[17]);
                    container.location = convertString(OneRow_Data[18]);
                    container.stationnum = convertInt(OneRow_Data[19]);
                    container.stationlist = convertString(OneRow_Data[20]);
                    container.faultcode = convertString(OneRow_Data[21]);
                    container.kitsresult = convertInt(OneRow_Data[22]);
                    container.reason = convertString(OneRow_Data[23]);
                    container.remark = convertString(OneRow_Data[24]);
                    container.workcontent = convertString(OneRow_Data[25]);
                    container.beforejson = convertString(OneRow_Data[26]);
                    container.afterjson = convertString(OneRow_Data[27]);
                    container.compid = convertInt(OneRow_Data[28]);
                    container.departid = convertInt(OneRow_Data[29]);
                    container.note = convertString(OneRow_Data[30]);
                    container.status = convertInt(OneRow_Data[31]);
                    container.reserve1 = convertString(OneRow_Data[32]);
                    container.reserve2 = convertString(OneRow_Data[33]);
                    container.reserve3 = convertString(OneRow_Data[34]);
                    container.reserve4 = convertString(OneRow_Data[35]);
                    container.reserve5 = convertString(OneRow_Data[36]);
                    container.createuser = convertString(OneRow_Data[37]);
                    container.createdate = convertString(OneRow_Data[38]);
                    container.updateuser = convertString(OneRow_Data[39]);
                    container.updatedate = convertString(OneRow_Data[40]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbKitsLog entity)
        {
            string jsonstr = JsonMapper.ToJson(entity);//把结构体各个变量转成Json格式的文本字符串
                                                       //JsonData B = JsonMapper.ToObject(A+'\n');
            Console.WriteLine("开始写入");
            char comma = ',';
            StringBuilder jsonStrBuilder = new StringBuilder(jsonstr);
            File_write(jsonStrBuilder.Append(comma).Append('\n').ToString(), path);
        }


    }
}
