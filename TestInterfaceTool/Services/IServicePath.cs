using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Services
{
    public interface IServicePath:IServicesInformation
    {
        Dictionary<string, string> GetPathDataSource();
    }
}
