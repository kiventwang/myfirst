using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core
{
    public class ConfigServerPathElements:ConfigurationElementCollection
    {
        
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigServerPathElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ConfigServerPathElement).ZhName;
        }

        public  ConfigServerPathElement this[int index]
        {
            get
            {
                return BaseGet(index) as ConfigServerPathElement;
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


        public new  ConfigServerPathElement this[string name]
        {
            get
            {
                return BaseGet(name) as ConfigServerPathElement;
            }
        }
       
        /*
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
         * */
    }
}
