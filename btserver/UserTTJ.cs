using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    struct TbUser
    {
        public string userid;
        public int usertype;
        public int compid;
        public int departid;
        public string username;
        public string password;
        public string phone;
        public string mail;
        public string rolecode;
        public string icon;
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

    class UserTTJ : BaseTxtToJson
    {

        public void readConvertFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            TbUser container = new TbUser();
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string lineString = line.ToString();
                string[] OneRow_Data = lineString.Split(';');
                if (OneRow_Data.Length > 0)
                {
                    container.userid = convertString(OneRow_Data[0]);
                    if (container.userid.Equals(""))
                    {
                        continue;
                    }
                    container.usertype = convertInt(OneRow_Data[1]);
                    container.compid = convertInt(OneRow_Data[2]);
                    container.departid = convertInt(OneRow_Data[3]);
                    container.username = convertString(OneRow_Data[4]);
                    container.password = convertString(OneRow_Data[5]);
                    container.phone = convertString(OneRow_Data[6]);
                    container.mail = convertString(OneRow_Data[7]);
                    container.rolecode = convertString(OneRow_Data[8]);
                    container.icon = convertString(OneRow_Data[9]);
                    container.status = convertInt(OneRow_Data[10]);
                    container.note = convertString(OneRow_Data[11]);
                    container.reserve1 = convertString(OneRow_Data[12]);
                    container.reserve2 = convertString(OneRow_Data[13]); ;
                    container.reserve3 = convertString(OneRow_Data[14]); ;
                    container.reserve4 = convertString(OneRow_Data[15]); ;
                    container.reserve5 = convertString(OneRow_Data[16]); ;
                    container.createuser = convertString(OneRow_Data[17]); ;
                    container.createdate = convertString(OneRow_Data[18]); ;
                    container.updateuser = convertString(OneRow_Data[19]); ;
                    container.updatedate = convertString(OneRow_Data[20]); ;
                    //单独考虑一个，OneRow_Data[3];还需要分割下
                    //string[] oneRowchild_child = OneRow_Data[3].Split('&');
                    //container.HZ_Merge = new List<string>();
                    //foreach (string A in oneRowchild_child)
                    //{
                    //    container.HZ_Merge.Add(A);
                    //}
                    ConvertJson(path, container);
                    Console.WriteLine(line.ToString());
                }
            }
        }



        private void ConvertJson(string path, TbUser tbUserText)
        {
            string jsonstr = JsonMapper.ToJson(tbUserText);//把结构体各个变量转成Json格式的文本字符串
                                                           //JsonData B = JsonMapper.ToObject(A+'\n');
            Console.WriteLine("开始写入");
            char comma = ',';
            StringBuilder jsonStrBuilder = new StringBuilder(jsonstr);
            File_write(jsonStrBuilder.Append(comma).Append('\n').ToString(), path);
        }


    }
}
