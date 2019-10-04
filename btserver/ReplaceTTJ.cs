using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbReplace
    {
        public string id;
        public int equipmentid;
        public string equipmenttype;
        public string kitstype;
        public string spindlecode;
        public string reasoncode;
        public string oldheadsn;
        public string oldlocation;
        public int oldcarrierlifewfrs;
        public int oldcarrierlifehrs;
        public int oldheadpmcounterwfrs;
        public int oldheadpmcounterhrs;
        public string oldmajorpartslifetimedetail;
        public int oldheadlifewfrs;
        public int oldheadlifehrs;
        public int oldmembranelifewfrs;
        public int oldmembranelifehrs;
        public int oldretaininglifewfrs;
        public int oldretaininglifehrs;
        public string newheadsn;
        public string newlocation;
        public int newcarrierlifewfrs;
        public int newcarrierlifehrs;
        public int newheadpmcounterwfrs;
        public int newheadpmcounterhrs;
        public string newmajorpartslifetimedetail;
        public int newheadlifewfrs;
        public int newheadlifehrs;
        public int newmembranelifewfrs;
        public int newmembranelifehrs;
        public int newretaininglifewfrs;
        public int newretaininglifehrs;
        public string remark;
        public string retestdate;
        public string retestreason;
        public string retestremark;
        public int reteststatus;
        public int replacestatus;
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

    class ReplaceTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbReplace container = new TbReplace();
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
                    container.equipmentid = convertInt(OneRow_Data[1]);
                    container.equipmenttype = convertString(OneRow_Data[2]);
                    container.kitstype = convertString(OneRow_Data[3]);
                    container.spindlecode = convertString(OneRow_Data[4]);
                    container.reasoncode = convertString(OneRow_Data[5]);
                    container.oldheadsn = convertString(OneRow_Data[6]);
                    container.oldlocation = convertString(OneRow_Data[7]);
                    container.oldcarrierlifewfrs = convertInt(OneRow_Data[8]);
                    container.oldcarrierlifehrs = convertInt(OneRow_Data[9]);
                    container.oldheadpmcounterwfrs = convertInt(OneRow_Data[10]);
                    container.oldheadpmcounterhrs = convertInt(OneRow_Data[11]);
                    container.oldmajorpartslifetimedetail = convertString(OneRow_Data[12]);
                    container.oldheadlifewfrs = convertInt(OneRow_Data[13]);
                    container.oldheadlifehrs = convertInt(OneRow_Data[14]);
                    container.oldmembranelifewfrs = convertInt(OneRow_Data[15]);
                    container.oldmembranelifehrs = convertInt(OneRow_Data[16]);
                    container.oldretaininglifewfrs = convertInt(OneRow_Data[17]);
                    container.oldretaininglifehrs = convertInt(OneRow_Data[18]);
                    container.newheadsn = convertString(OneRow_Data[19]);
                    container.newlocation = convertString(OneRow_Data[20]);
                    container.newcarrierlifewfrs = convertInt(OneRow_Data[21]);
                    container.newcarrierlifehrs = convertInt(OneRow_Data[22]);
                    container.newheadpmcounterwfrs = convertInt(OneRow_Data[23]);
                    container.newheadpmcounterhrs = convertInt(OneRow_Data[24]);
                    container.newmajorpartslifetimedetail = convertString(OneRow_Data[25]);
                    container.newheadlifewfrs = convertInt(OneRow_Data[26]);
                    container.newheadlifehrs = convertInt(OneRow_Data[27]);
                    container.newmembranelifewfrs = convertInt(OneRow_Data[28]);
                    container.newmembranelifehrs = convertInt(OneRow_Data[29]);
                    container.newretaininglifewfrs = convertInt(OneRow_Data[30]);
                    container.newretaininglifehrs = convertInt(OneRow_Data[31]);
                    container.remark = convertString(OneRow_Data[32]);
                    container.retestdate = convertString(OneRow_Data[33]);
                    container.retestreason = convertString(OneRow_Data[34]);
                    container.retestremark = convertString(OneRow_Data[35]);
                    container.reteststatus = convertInt(OneRow_Data[36]);
                    container.replacestatus = convertInt(OneRow_Data[37]);
                    container.compid = convertInt(OneRow_Data[38]);
                    container.departid = convertInt(OneRow_Data[39]);
                    container.status = convertInt(OneRow_Data[40]);
                    container.reserve1 = convertString(OneRow_Data[41]);
                    container.reserve2 = convertString(OneRow_Data[42]);
                    container.reserve3 = convertString(OneRow_Data[43]);
                    container.reserve4 = convertString(OneRow_Data[44]);
                    container.reserve5 = convertString(OneRow_Data[45]);
                    container.createuser = convertString(OneRow_Data[46]);
                    container.createdate = convertString(OneRow_Data[47]);
                    container.updateuser = convertString(OneRow_Data[48]);
                    container.updatedate = convertString(OneRow_Data[49]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbReplace tbBom)
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
