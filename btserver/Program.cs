using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btserver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm shell = new mainForm();
            if (shell.IsBlueToothAble)
            {
                Application.Run(shell);
            }
            else
            {
                Application.Exit();
            }
            //UserTTJ readUser =  new UserTTJ();
            //readUser.readConvertFile("c:\\bt/tbuser.txt");
            //sendRequestUploadDB("c:\\bt/tbuser.txt");
        }


    }
}
