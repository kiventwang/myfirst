using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigInterfaceInfoElements:ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigInterfaceInfoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ConfigInterfaceInfoElement).Key;
        }

        public ConfigInterfaceInfoElement this[int index]
        {
            get { return BaseGet(index) as ConfigInterfaceInfoElement; }
            set
            {
                if (BaseGet(index) != null)
                {
                    base.BaseRemove(index);
                }
                base.BaseAdd(index,value);
            }
        }

        public new ConfigInterfaceInfoElement this[string name]
        {
            get { return BaseGet(name) as ConfigInterfaceInfoElement; }
        }
    }
}
