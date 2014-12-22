using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestInterfaceTool.Core.FillData;
using TestInterfaceTool.Core.Model;

namespace TestInterfaceTool.Services
{
    public interface IServicesInformation
    {


        Dictionary<string, ServerPathModel> GetServerPath();

        Dictionary<string, RealInterfaceInfoModel> GetInterfaceName();

        Dictionary<string, SortNameModel> GetSortName();
    }
}
