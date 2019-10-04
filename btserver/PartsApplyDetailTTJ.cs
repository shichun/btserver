using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbPartsApplyDetail
    {
        public string id;
        public int partsapplyid;
        public int partsid;
        public string batchno;
        public string equipmenttype;
        public string kitstype;
        public string partstype;
        public string partsname;
        public int applynum;
        public int warehousenum;
        public int warnnum;
        public string approveuser;
        public int applystatus;
        public int compid;
        public int departid;
        public int status;
        public string note;
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

    class PartsApplyDetailTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbPartsApplyDetail container = new TbPartsApplyDetail();
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
                    container.partsapplyid = convertInt(OneRow_Data[1]);
                    container.partsid = convertInt(OneRow_Data[2]);
                    container.batchno = convertString(OneRow_Data[3]);
                    container.equipmenttype = convertString(OneRow_Data[4]);
                    container.kitstype = convertString(OneRow_Data[5]);
                    container.partstype = convertString(OneRow_Data[6]);
                    container.partsname = convertString(OneRow_Data[7]);
                    container.applynum = convertInt(OneRow_Data[8]);
                    container.warehousenum = convertInt(OneRow_Data[9]);
                    container.warnnum = convertInt(OneRow_Data[10]);
                    container.approveuser = convertString(OneRow_Data[11]);
                    container.applystatus = convertInt(OneRow_Data[12]);
                    container.compid = convertInt(OneRow_Data[13]);
                    container.departid = convertInt(OneRow_Data[14]);
                    container.status = convertInt(OneRow_Data[15]);
                    container.note = convertString(OneRow_Data[16]);
                    container.reserve1 = convertString(OneRow_Data[17]);
                    container.reserve2 = convertString(OneRow_Data[18]);
                    container.reserve3 = convertString(OneRow_Data[19]);
                    container.reserve4 = convertString(OneRow_Data[20]);
                    container.reserve5 = convertString(OneRow_Data[21]);
                    container.createuser = convertString(OneRow_Data[22]);
                    container.createdate = convertString(OneRow_Data[23]);
                    container.updateuser = convertString(OneRow_Data[24]);
                    container.updatedate = convertString(OneRow_Data[25]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbPartsApplyDetail tbBom)
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
