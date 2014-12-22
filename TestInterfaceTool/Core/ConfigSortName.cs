using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigSortName:ConfigurationElement
    {
        [ConfigurationProperty("sortName", IsRequired = true)]
        public string SortName
        {
            get { return this["sortName"] as string; }
            set { this["sortName"] = value; }
        }

        [ConfigurationProperty("sortPath",IsRequired = true)]
        public string SortPath
        {
            get { return this["sortPath"] as string; }
            set { this["sortPath"] = value; }
        }
    }
}
