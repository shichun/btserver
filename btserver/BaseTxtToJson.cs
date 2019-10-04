using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btserver
{
    abstract class BaseTxtToJson
    {
        public void File_write(string jsonData, string path)
        {//1.建立流  2.建立字节块数组，3.写进去
            do
            {
                string writePath = path.Replace(".txt", ".json");
                FileStream Write = new FileStream(writePath, FileMode.Append);//写入的第一种操作函数，参数1表示流指向的路径文件，后面是访问文件的模式，
                //Append打开文件，流指向文件的末尾，
                Byte[] byte_txt = new UTF8Encoding().GetBytes(jsonData);//把字符串变成字节块
                //File.WriteAllBytes(writePath, byte_txt);
                //FileStream Write = File.Create(writePath, byte_txt.Length, FileOptions.Asynchronous);
                Write.Write(byte_txt, 0, byte_txt.Length);
                Write.Flush();
                Write.Close();
            } while (false);
        }

        public string convertString(string str)
        {
            return str.Equals("\\N") ? "" : str;
        }

        public int convertInt(string str) {
            try
            {
                return int.Parse(str.Equals("\\N") ? "-1" : str);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                str = str.Substring(0, str.IndexOf("."));
                return (int)long.Parse(str.Equals("\\N") ? "-1" : str);
            }
           
        }
    }
}
