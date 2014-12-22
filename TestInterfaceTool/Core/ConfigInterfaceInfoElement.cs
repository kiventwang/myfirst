using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigInterfaceInfoElement:ConfigurationElement
    {
        [ConfigurationProperty("showName",IsRequired = true)]
        public string ShowName
        {
            get { return this["showName"] as string; }
            set { this["showName"] = value; }
        }

        [ConfigurationProperty("key",IsRequired = true)]
        public string Key
        {
            get { return this["key"] as string; }
            set { this["key"] = value; }
        }


        [ConfigurationProperty("interfaceName",IsRequired = true)]
        public string InterfaceName
        {
            get { return this["interfaceName"] as string; }
            set { this["interfaceName"] = value; }
        }
    }
}
