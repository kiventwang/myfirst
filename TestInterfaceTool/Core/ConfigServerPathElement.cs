using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigServerPathElement:ConfigurationElement
    {
        [ConfigurationProperty("zhName",IsRequired = true)]
        public string ZhName
        {
            get { return base["zhName"] as string; }
            set { base["zhName"] = value; }
        }

        [ConfigurationProperty("enName",IsRequired = true)]
        public string EnName
        {
            get { return base["enName"] as string; }
            set { base["enName"] = value; }
        }

        [ConfigurationProperty("port",IsRequired = true)]
        public string Port
        {
            get { return this["port"] as string; }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }



    }
}
