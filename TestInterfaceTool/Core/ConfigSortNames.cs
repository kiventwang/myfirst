using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigSortNames:ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigSortName();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ConfigSortName).SortName;
        }

        public ConfigSortName this[int index]
        {
            get
            {
                return BaseGet(index) as ConfigSortName;
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }


        public new ConfigSortName this[string name]
        {
            get
            {
                return BaseGet(name) as ConfigSortName;
            }
        }
    }
}
