using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbMaintenanceType
    {
        public string id;
        public string name;
        public string maintaincondition;
        public string equipmenttype;
        public string kitstype;
        public string testtypeids;
        public string maintenances;
        public int pmcountzero;
        public string docinfo;
        public string note;
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

    class MaintenanceTypeTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbMaintenanceType container = new TbMaintenanceType();
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
                    container.name = convertString(OneRow_Data[1]);
                    container.maintaincondition = convertString(OneRow_Data[2]);
                    container.equipmenttype = convertString(OneRow_Data[3]);
                    container.kitstype = convertString(OneRow_Data[4]);
                    container.testtypeids = convertString(OneRow_Data[5]);
                    container.maintenances = convertString(OneRow_Data[6]);
                    container.pmcountzero = convertInt(OneRow_Data[7]);
                    container.docinfo = convertString(OneRow_Data[8]);
                    container.note = convertString(OneRow_Data[9]);
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



        private void ConvertJson(string path, TbMaintenanceType tbBom)
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
