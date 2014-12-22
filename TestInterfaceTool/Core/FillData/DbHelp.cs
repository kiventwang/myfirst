using System;

namespace TestInterfaceTool.Core.FillData
{
    public class DbHelp
    {
        private static string ObjName = "TestInterfaceTool.Core.FillData.{0}";
        private static string AssemblyName = "TestInterfaceTool";

        public static IRespository Instance
        {
            get
            {
                return
                    (IRespository)
                        Activator.CreateInstance(Type.GetType(string.Format(ObjName, AssemblyName, "RespositoryBase")));
            }
        }
    }
}
