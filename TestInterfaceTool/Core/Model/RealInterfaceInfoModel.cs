using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestInterfaceTool.Core.Model
{
    public class RealInterfaceInfoModel
    {
        /// <summary>
        /// 接口名称
        /// </summary>
        public string Name { get; set; }


        public string Key { get; set; }

        /// <summary>
        /// 显示在下拉列表框中的数据
        /// </summary>
        public string ShowName { get; set; }
    }
}
