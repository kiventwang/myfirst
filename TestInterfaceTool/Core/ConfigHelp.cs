using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigHelp
    {

        public T GetConfigSectionInfomation<T>(string name) where T:ConfigurationSection
        {
            return ConfigurationManager.GetSection(name) as T;
        }
    }
}
