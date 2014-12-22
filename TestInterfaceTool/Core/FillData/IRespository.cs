using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestInterfaceTool.Core.Model;

namespace TestInterfaceTool.Core.FillData
{
    public interface IRespository
    {
        Dictionary<string,ServerPathModel> GetServerPath();

        Dictionary<string,RealInterfaceInfoModel> GetInterfaceName();

        Dictionary<string, SortNameModel> GetSortName();
        
        ConfigHelp ConfigHelpInstance { get; }


    }
}
