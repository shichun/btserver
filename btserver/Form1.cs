using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btserver
{
    public partial class mainForm : Form
    {
        BluetoothRadio radio = null;//蓝牙适配器  
        ObexListener listener = null;//监听器  
        string recDir = null;//接受文件存放目录  
        Thread listenThread;
        Dictionary<string, string> dtoMap = new Dictionary<string, string>();
        public mainForm()
        {
            InitializeComponent();
            //recDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            initDtoMap();
            recDir = fileLocationLabel.Text;
            if (!Directory.Exists(recDir))
            {
                Directory.CreateDirectory("/bt");
            }
            fileLocationLabel.Text = recDir;
            checkBlueTooth();
            //uploadJsonServer("");
            //testUploadFile();
        }

        private void checkBlueTooth()
        {
            radio = BluetoothRadio.PrimaryRadio;//获取当前PC的蓝牙适配器  
            if (radio == null)//检查该电脑蓝牙是否可用  
            {
                isBlueToothAble = false;
                MessageBox.Show("这个电脑蓝牙不可用,请先打开蓝牙，再打开应用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                isBlueToothAble = true;
                radio.Mode = RadioMode.Connectable;
                CheckForIllegalCrossThreadCalls = false;//不检查跨线程调用  
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listener == null || !listener.IsListening)
            {
                radio.Mode = RadioMode.Discoverable;//设置本地蓝牙可被检测  
                listener = new ObexListener(ObexTransport.Bluetooth);//创建监听  
                listener.Start();
                if (listener.IsListening)
                {
                    buttonListener.Text = "停止";
                    ListenerStatusInfo.Text = "开始监听";
                    listenThread = new Thread(receiveFile);//开启监听线程  
                    listenThread.Start();
                }
            }
            else
            {
                listener.Stop();
                buttonListener.Text = "监听";
                ListenerStatusInfo.Text = "停止监听";
            }
        }

        private void receiveFile()//收文件方法  
        {
            ObexListenerContext context = null;
            ObexListenerRequest request = null;
            while (listener.IsListening)
            {
                context = listener.GetContext();//获取监听上下文  
                if (context == null)
                {
                    break;
                }
                request = context.Request;//获取请求  
                string uriString = Uri.UnescapeDataString(request.RawUrl);//将uri转换成字符串  
                string recFilePathName = recDir + uriString;
                request.WriteFile(recFilePathName);//接收文件 
                if (recFilePathName != null || recFilePathName != "")
                {
                    //获得当前连接设备信息
                    radio = BluetoothRadio.PrimaryRadio;
                    string recFileName = recFilePathName.Substring(recFilePathName.LastIndexOf("/") + 1);
                    convertToJsonFileByFileName(recFileName);//转化为json文件
                    uploadJsonServer(recFileName);//通知本地java服务器读取jsonFile
                    ListenerStatusInfo.Text = "收到文件" + uriString.TrimStart(new char[] { '/' });
                }
            }
        }

        private void testUploadFile() {
            string recFileName = "tbrebuiltlist.txt";
            convertToJsonFileByFileName(recFileName);//转化为json文件
            uploadJsonServer(recFileName);//通知本地java服务器读取jsonFile
        }
        private void convertToJsonFileByFileName(string recFileName)
        {
            
                switch (recFileName)
                {
                    case "tbuser.txt":
                        UserTTJ readUser = new UserTTJ();
                        readUser.readConvertFile("c:\\bt/tbuser.txt");
                        break;
                    case "tbblackbatch.txt":
                        BlackbatchTTJ blackBatch = new BlackbatchTTJ();
                        blackBatch.readConvertFile("c:\\bt/tbblackbatch.txt");
                        break;
                    case "tbbom.txt":
                        BomTTJ bom = new BomTTJ();
                        bom.readConvertFile("c:\\bt/tbbom.txt");
                        break;
                    case "tbcode.txt":
                        CodeTTJ code = new CodeTTJ();
                        code.readConvertFile("c:\\bt/tbcode.txt");
                        break;
                    case "tbequipment.txt":
                        EquipmentTTJ equipmentTTJ = new EquipmentTTJ();
                        equipmentTTJ.readConvertFile("c:\\bt/tbequipment.txt");
                        break;
                    case "tbequipmentspindlelog.txt":
                        EquipmentSpindleLogTTJ equipmentSpindleLogTTJ = new EquipmentSpindleLogTTJ();
                        equipmentSpindleLogTTJ.readConvertFile("c:\\bt/tbequipmentspindlelog.txt");
                        break;
                    case "tbfaultcode.txt":
                        FaultCodeTTJ faultCodeTTJ = new FaultCodeTTJ();
                        faultCodeTTJ.readConvertFile("c:\\bt/tbfaultcode.txt");
                        break;
                    case "tbkits.txt":
                        KitsTTJ kitsTTJ = new KitsTTJ();
                        kitsTTJ.readConvertFile("c:\\bt/tbkits.txt");
                        break;
                    case "tbkitslog.txt":
                        KitsLogTTJ kitsLogTTJ = new KitsLogTTJ();
                        kitsLogTTJ.readConvertFile("c:\\bt/tbkitslog.txt");
                        break;
                    case "tbmaintenancetype.txt":
                        MaintenanceTypeTTJ maintenanceTypeTTJ = new MaintenanceTypeTTJ();
                        maintenanceTypeTTJ.readConvertFile("c:\\bt/tbmaintenancetype.txt");
                        break;
                    case "tbmajorparts.txt":
                        MajorPartsTTJ majorPartsTTJ = new MajorPartsTTJ();
                        majorPartsTTJ.readConvertFile("c:\\bt/tbmajorparts.txt");
                        break;
                    case "tbmajorpartslog.txt":
                        MajorPartsLogTTJ majorPartsLogTTJ = new MajorPartsLogTTJ();
                        majorPartsLogTTJ.readConvertFile("c:\\bt/tbmajorpartslog.txt");
                        break;
                    case "tbmanufacturer.txt":
                        ManufacturerTTJ manufacturerTTJ = new ManufacturerTTJ();
                        manufacturerTTJ.readConvertFile("c:\\bt/tbmanufacturer.txt");
                        break;
                    case "tborder.txt":
                        OrderTTJ orderTTJ = new OrderTTJ();
                        orderTTJ.readConvertFile("c:\\bt/tborder.txt");
                        break;
                    case "tborderdetail.txt":
                        OrderDetailTTJ orderDetailTTJ = new OrderDetailTTJ();
                        orderDetailTTJ.readConvertFile("c:\\bt/tborderdetail.txt");
                        break;
                    case "tbparts.txt":
                        PartsTTJ partsTTJ = new PartsTTJ();
                        partsTTJ.readConvertFile("c:\\bt/tbparts.txt");
                        break;
                    case "tbpartsapply.txt":
                        PartsApplyTTJ partsApplyTTJ = new PartsApplyTTJ();
                        partsApplyTTJ.readConvertFile("c:\\bt/tbpartsapply.txt");
                        break;
                    case "tbpartsapplydetail.txt":
                        PartsApplyDetailTTJ partsApplyDetailTTJ = new PartsApplyDetailTTJ();
                        partsApplyDetailTTJ.readConvertFile("c:\\bt/tbpartsapplydetail.txt");
                        break;
                    case "tbpartslog.txt":
                        PartsLogTTJ partsLogTTJ = new PartsLogTTJ();
                        partsLogTTJ.readConvertFile("c:\\bt/tbpartslog.txt");
                        break;
                    case "tbpartswarehouse.txt":
                        PartsWareHouseTTJ partsWareHouseTTJ = new PartsWareHouseTTJ();
                        partsWareHouseTTJ.readConvertFile("c:\\bt/tbpartswarehouse.txt");
                        break;
                    case "tbpartswarehouselog.txt":
                        PartsWareHouseLogTTJ partsWareHouseLogTTJ = new PartsWareHouseLogTTJ();
                        partsWareHouseLogTTJ.readConvertFile("c:\\bt/tbpartswarehouselog.txt");
                        break;
                    case "tbrebuilt.txt":
                        RebuiltTTJ rebuiltTTJ = new RebuiltTTJ();
                        rebuiltTTJ.readConvertFile("c:\\bt/tbrebuilt.txt");
                        break;
                    case "tbrebuiltlist.txt":
                        RebuiltListTTJ rebuiltListTTJ = new RebuiltListTTJ();
                        rebuiltListTTJ.readConvertFile("c:\\bt/tbrebuiltlist.txt");
                        break;
                    case "tbreplace.txt":
                        ReplaceTTJ replaceTTJ = new ReplaceTTJ();
                        replaceTTJ.readConvertFile("c:\\bt/tbreplace.txt");
                        break;
                    case "tbtesting.txt":
                        TestingTTJ testingTTJ = new TestingTTJ();
                        testingTTJ.readConvertFile("c:\\bt/tbtesting.txt");
                        break;
                    case "tbtestingtype.txt":
                        TestingTypeTTJ testingTypeTTJ = new TestingTypeTTJ();
                        testingTypeTTJ.readConvertFile("c:\\bt/tbtestingtype.txt");
                        break;
                    case "tbtestingval.txt":
                        TestingValTTJ testingValTTJ = new TestingValTTJ();
                        testingValTTJ.readConvertFile("c:\\bt/tbtestingval.txt");
                        break;
                    case "tbtestparam.txt":
                        TestParamTTJ testParamTTJ = new TestParamTTJ();
                        testParamTTJ.readConvertFile("c:\\bt/tbtestparam.txt");
                        break;
                    case "tbtesttype.txt":
                        TestTypeTTJ testTypeTTJ = new TestTypeTTJ();
                        testTypeTTJ.readConvertFile("c:\\bt/tbtesttype.txt");
                        break;
            }
        }

        private void uploadJsonServer(string recFileName)
        {
            HttpClientRequester httpclient = HttpClientRequester.Instance;
            //string dataContent= httpclient.getDataConent(recFileName);
            string dataType = getDataTypeByFileName(recFileName);
            httpclient.PostRequest(dataType, recFileName);

          //  File.ReadLines();
        }

        private void initDtoMap() {
            dtoMap.Add("tbblackbatch.txt", "BlackBatch");
            dtoMap.Add("tbbom.txt", "Bom");
            dtoMap.Add("tbcode.txt", "Code");
            dtoMap.Add("tbequipment.txt", "Equipment");
            dtoMap.Add("tbequipmentspindlelog.txt", "EquipmentSpindleLog");
            dtoMap.Add("tbfaultcode.txt", "FaultCode");
            dtoMap.Add("tbkits.txt", "Kits");
            dtoMap.Add("tbkitslog.txt", "KitsLog");
            dtoMap.Add("tbmaintenancetype.txt", "MaintenanceType");
            dtoMap.Add("tbmajorparts.txt", "MajorParts");
            dtoMap.Add("tbmajorpartslog.txt", "MajorPartsLog");
            dtoMap.Add("tbmanufacturer.txt", "Manufacturer");
            dtoMap.Add("tborder.txt", "Order");
            dtoMap.Add("tborderdetail.txt", "OrderDetail");
            dtoMap.Add("tbparts.txt", "Parts");
            dtoMap.Add("tbpartsapply.txt", "Partsapply");
            dtoMap.Add("tbpartsapplydetail.txt", "Partsapplydetail");
            dtoMap.Add("tbpartslog.txt", "Partslog");
            dtoMap.Add("tbpartswarehouse.txt", "Partswarehouse");
            dtoMap.Add("tbpartswarehouselog.txt", "Partswarehouselog");
            dtoMap.Add("tbrebuilt.txt", "Rebuilt");
            dtoMap.Add("tbrebuiltlist.txt", "RebuiltList");
            dtoMap.Add("tbreplace.txt", "Replace");
            dtoMap.Add("tbtesting.txt", "Testing");
            dtoMap.Add("tbtestingtype.txt", "TestingType");
            dtoMap.Add("tbtestingval.txt", "TestingVal");
            dtoMap.Add("tbtestparam.txt", "TestParam");
            dtoMap.Add("tbtesttype.txt", "TestType");
            dtoMap.Add("tbuser.txt", "User");
        }
        private string getDataTypeByFileName(string fileName) {
            return dtoMap[fileName];
        }
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            if (listenThread != null)
            {
                listenThread.Abort();
            }
            if (listener != null && listener.IsListening)
            {
                listener.Stop();
            }
        }

        private void ChangeLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择蓝牙接收文件的存放路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                recDir = dialog.SelectedPath;
                fileLocationLabel.Text = recDir;
            }
        }
    }
}
