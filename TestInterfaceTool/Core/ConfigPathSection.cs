using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TestInterfaceTool.Core
{
    public class ConfigPathSection:ConfigurationSection
    {

        [ConfigurationProperty("elements",IsRequired = true)]
        public ConfigServerPathElements Elements
        {
            get
            {
                return this["elements"] as ConfigServerPathElements;
            }

            private set { }
        }


        [ConfigurationProperty("interfaceInfoElements",IsRequired = true)]
        public ConfigInterfaceInfoElements InterfaceInfoElements
        {
            get { return this["interfaceInfoElements"] as ConfigInterfaceInfoElements; }
            private  set{}
        }

        [ConfigurationProperty("sortNames", IsRequired = true)]
        public ConfigSortNames SortNames
        {
            get { return this["sortNames"] as ConfigSortNames; }
            private set { }
        }
    }
}
