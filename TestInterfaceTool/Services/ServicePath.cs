using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestInterfaceTool.Core.FillData;
using TestInterfaceTool.ViewModel;

namespace TestInterfaceTool.Services
{
    public class ServicePath:ServiceInformationBase,IServicePath
    {
        public Dictionary<string, string> GetPathDataSource()
        {
            var dataSource = base.GetServerPath();
            int i = 0;
            foreach (var item in dataSource.Values)
            {
                var dataSourceDic = new Dictionary<string, string>();
                var viewPathComboxDataSourceModel = new ViewPathComboxDataSourceModel();
                viewPathComboxDataSourceModel.ShowName = item.Name;
                viewPathComboxDataSourceModel.RealKey = i.ToString();
                i++;
            }
            return null;
        }
    }
}
