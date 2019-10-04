﻿using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbPartsWareHouseLog
    {
        public string id;
        public int equipmentid;
        public int kitsid;
        public string equipmenttype;
        public string kitstype;
        public string partstype;
        public string partssn;
        public string batchno;
        public string expireday;
        public int logtype;
        public int changenum;
        public int beforenum;
        public int afternum;
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

    class PartsWareHouseLogTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbPartsWareHouseLog container = new TbPartsWareHouseLog();
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
                    container.kitsid = convertInt(OneRow_Data[2]);
                    container.equipmenttype = convertString(OneRow_Data[3]);
                    container.kitstype = convertString(OneRow_Data[4]);
                    container.partstype = convertString(OneRow_Data[5]);
                    container.partssn = convertString(OneRow_Data[6]);
                    container.batchno = convertString(OneRow_Data[7]);
                    container.expireday = convertString(OneRow_Data[8]);
                    container.logtype = convertInt(OneRow_Data[9]);
                    container.changenum = convertInt(OneRow_Data[10]);
                    container.beforenum = convertInt(OneRow_Data[11]);
                    container.afternum = convertInt(OneRow_Data[12]);
                    container.compid = convertInt(OneRow_Data[13]);
                    container.departid = convertInt(OneRow_Data[14]);
                    container.status = convertInt(OneRow_Data[15]);
                    container.reserve1 = convertString(OneRow_Data[16]);
                    container.reserve2 = convertString(OneRow_Data[17]);
                    container.reserve3 = convertString(OneRow_Data[18]);
                    container.reserve4 = convertString(OneRow_Data[19]);
                    container.reserve5 = convertString(OneRow_Data[20]);
                    container.createuser = convertString(OneRow_Data[21]);
                    container.createdate = convertString(OneRow_Data[22]);
                    container.updateuser = convertString(OneRow_Data[23]);
                    container.updatedate = convertString(OneRow_Data[24]);

                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbPartsWareHouseLog tbBom)
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
