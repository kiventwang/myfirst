using System;
using System.Collections.Generic;
using TestInterfaceTool.Core.Model;

namespace TestInterfaceTool.Core.FillData
{

    public class RespositoryBase : IRespository
    {
        private object lockObj = new Object();
        private const string sectionName = "interfacePath";


        private ConfigHelp _configHelp;
        public ConfigHelp ConfigHelpInstance
        {
            get
            {
                if (_configHelp == null)
                {
                    lock (lockObj)
                    {
                        if (_configHelp == null)
                        {
                            _configHelp = new ConfigHelp();
                        }
                    }
                }
                return _configHelp;
            }
        }

        

        public Dictionary<string, ServerPathModel> GetServerPath()
        {
            var sectionInfomation = ConfigHelpInstance.GetConfigSectionInfomation<ConfigPathSection>(sectionName);
            var serverPathElements = sectionInfomation.Elements;
            var serverPathDic = new Dictionary<string, ServerPathModel>();
            for (int i = 0; i < serverPathElements.Count; i++)
            {
                var serverpathModel = new ServerPathModel();
                serverpathModel.Name = serverPathElements[i].ZhName;
                serverpathModel.Path = serverPathElements[i].EnName;
                serverpathModel.Port = serverPathElements[i].Port;
                serverPathDic.Add(i.ToString(), serverpathModel);
            }
            return serverPathDic;
        }


        public Dictionary<string, RealInterfaceInfoModel> GetInterfaceName()
        {
            var sectionInfomation = ConfigHelpInstance.GetConfigSectionInfomation<ConfigPathSection>(sectionName);
            var interfaceInforElements = sectionInfomation.InterfaceInfoElements;
            var serverPathDic = new Dictionary<string, RealInterfaceInfoModel>();
            for (int i = 0; i < interfaceInforElements.Count; i++)
            {
                var realInterfaceInfoModel = new RealInterfaceInfoModel();
                realInterfaceInfoModel.Name = interfaceInforElements[i].InterfaceName;
                realInterfaceInfoModel.ShowName = interfaceInforElements[i].ShowName;
                realInterfaceInfoModel.Key = interfaceInforElements[i].Key;
                serverPathDic.Add(i.ToString(), realInterfaceInfoModel);
            }
            return serverPathDic;
        }




        public Dictionary<string, SortNameModel> GetSortName()
        {
            var sectionInfomation = ConfigHelpInstance.GetConfigSectionInfomation<ConfigPathSection>(sectionName);
            var sortNames = sectionInfomation.SortNames;
            var sortNameDic = new Dictionary<string, SortNameModel>();
            for (int i = 0; i < sortNames.Count; i++)
            {
                var sortNameModel = new SortNameModel();
                sortNameModel.SortName = sortNames[i].SortName;
                sortNameModel.SortPath = sortNames[i].SortPath;
                sortNameDic.Add(i.ToString(), sortNameModel);
            }
            return sortNameDic;
        }
    }
}
