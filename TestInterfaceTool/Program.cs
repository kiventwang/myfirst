using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using TestInterfaceTool.ContainerManager;
using TestInterfaceTool.Core.FillData;
using TestInterfaceTool.Services;

namespace TestInterfaceTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = AutofacContainerManager.AutofacBuilder;
            builder.RegisterType<RespositoryBase>().As<IRespository>();
            builder.RegisterType<ServiceInformationBase>().As<IServicesInformation>();
            Application.Run(new ToolForHkc());
        }
    }
}
