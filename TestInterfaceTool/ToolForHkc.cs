using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestInterfaceTool.Core.Model;
using TestInterfaceTool.Services;
using System.Net;

namespace TestInterfaceTool
{
    public partial class ToolForHkc : BaseForm
    {
        private Dictionary<string, ServerPathModel> servicePathDataSource = new Dictionary<string, ServerPathModel>();
        private Dictionary<string,RealInterfaceInfoModel> interfaceInformationDataSource = new Dictionary<string, RealInterfaceInfoModel>();
        private Dictionary<string,SortNameModel> sortNameDataSource = new Dictionary<string, SortNameModel>();
        public ToolForHkc()
        {
            

            InitializeComponent();
        }

        private void ToolForHkc_Load(object sender, EventArgs e)
        {

            //-------------服务地址信息
            servicePathDataSource = LoadServices<IServicesInformation>().GetServerPath();
            this.ServicesPath.DataSource = servicePathDataSource.Values.ToList();
            ServicesPath.ValueMember = "Port";
            ServicesPath.DisplayMember = "Name";
            this.txtServicePath.Text = servicePathDataSource.Values.ToList().FirstOrDefault().Path;

            //------------接口分类
            sortNameDataSource = LoadServices<IServicesInformation>().GetSortName();
            this.cmbInterfaceSort.DataSource = sortNameDataSource.Values.ToList();
            this.cmbInterfaceSort.ValueMember = "SortPath";
            this.cmbInterfaceSort.DisplayMember = "SortName";
            this.txtInterfaceSort.Text = sortNameDataSource.Values.ToList().FirstOrDefault().SortPath;



            //------------接口名称信息
            interfaceInformationDataSource = LoadServices<IServicesInformation>().GetInterfaceName();
            this.InterfaceName.DataSource = interfaceInformationDataSource.Values.ToList();
            InterfaceName.ValueMember = "Key";
            InterfaceName.DisplayMember = "ShowName";
            this.txtInterface.Text = interfaceInformationDataSource.Values.ToList().FirstOrDefault().Name;





        }

      

        private void ServicesPath_TextChanged(object sender, EventArgs e)
        {
            var selectedValue = this.ServicesPath.SelectedItem as ServerPathModel;
            this.txtServicePath.Text = servicePathDataSource.Values.ToList().FirstOrDefault(p => p.Port == selectedValue.Port).Path;

        }

        private void InterfaceName_TextChanged(object sender, EventArgs e)
        {
            var selectedValue = this.InterfaceName.SelectedItem as RealInterfaceInfoModel;
            this.txtInterface.Text =
                interfaceInformationDataSource.Values.ToList().FirstOrDefault(i => i.Key == selectedValue.Key).Name;
        }

        private void cmbInterfaceSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = this.cmbInterfaceSort.SelectedItem as SortNameModel;
            this.txtInterfaceSort.Text =
                sortNameDataSource.Values.ToList().FirstOrDefault(p => p.SortPath == selectedValue.SortPath).SortPath;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            var path = this.txtServicePath.Text;
            var port = (this.ServicesPath.SelectedItem as ServerPathModel).Port;
            var sortPath = (this.cmbInterfaceSort.SelectedItem as SortNameModel).SortPath;
            if (!string.IsNullOrEmpty(port))
                path = path + ":" + port + "/" + sortPath + "/";
            var interfaceName = this.txtInterface.Text;
            path += interfaceName;
            var outMessage = StartCommit(path,this.txtInputArg.Text);
            this.txtOut.Text = outMessage;
        }

        private string StartCommit(string path,string paramData)
        {
            HttpWebRequest client =(HttpWebRequest)HttpWebRequest.Create(new Uri(path));
            client.Method = "POST";
            client.ContentType = "application/json";
            byte[] byteArray = Encoding.Default.GetBytes(paramData); 
            client.ContentLength = byteArray.Length;
            Stream newStream = client.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) client.GetResponse();
            }
            catch (Exception ex)
            {
                newStream.Close();
                return "获取返回值出现错误："+ex.Message;
            }
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string ret = sr.ReadToEnd();
            sr.Close();
            response.Close();
            newStream.Close();
            return ret;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var port = (this.ServicesPath.SelectedItem as ServerPathModel).Port;
            var interfaceName = this.txtInterface.Text;
            var savePath = AppDomain.CurrentDomain.BaseDirectory + "ArgInput";
            var directoryName = port + "(" + interfaceName + ")";
            var realSavePath = savePath + "\\" + directoryName;
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            if (!Directory.Exists(realSavePath))
                Directory.CreateDirectory(realSavePath);
            //构造文件
            var filePath = realSavePath + "\\" + "test.txt";
            if (!File.Exists(filePath))
            {
                using (var sw = File.CreateText(filePath))
                {
                    sw.Write(this.txtInputArg.Text);
                }
            }
            else
            {
                File.Delete(filePath);//删除后重新构造
                using (var sw = File.CreateText(filePath))
                {
                    sw.Write(this.txtInputArg.Text);
                }
            }
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var port = (this.ServicesPath.SelectedItem as ServerPathModel).Port;
            var interfaceName = this.txtInterface.Text;
            var savePath = AppDomain.CurrentDomain.BaseDirectory + "ArgInput";
            var directoryName = port + "(" + interfaceName + ")";
            var realSavePath = savePath + "\\" + directoryName;
            if(Directory.Exists(savePath)&&Directory.Exists(realSavePath))
            {
                var filePath = realSavePath + "\\" + "test.txt";
                if (File.Exists(filePath))
                {
                    using (var sw = File.OpenRead(filePath))
                    {
                        byte[] result = new byte[sw.Length];
                        UTF8Encoding encoding = new UTF8Encoding(true);
                        sw.Read(result, 0, result.Length);
                        this.txtInputArg.Text = encoding.GetString(result);
                    }
                }    
            }
        }

      
        
    }
}
