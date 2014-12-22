using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using TestInterfaceTool.ContainerManager;
using TestInterfaceTool.Services;

namespace TestInterfaceTool
{
    public class BaseForm:Form
    {
        protected virtual TServices LoadServices<TServices>() where TServices : IServicesInformation
        {
            var container = AutofacContainerManager.AutofacContainer;
           return container.Resolve<TServices>();
            
        }

    }
}
