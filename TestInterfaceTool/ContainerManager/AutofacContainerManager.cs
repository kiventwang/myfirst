using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace TestInterfaceTool.ContainerManager
{
    public class AutofacContainerManager
    {
        private static object obj = null;

        private static object lockObj = new object();

        private static ContainerBuilder _autofacBuilder;
        public static ContainerBuilder AutofacBuilder
        {
            get
            {
                if (_autofacBuilder == null)
                {
                    lock (lockObj)
                    {
                        if (_autofacBuilder == null)
                        {
                            _autofacBuilder = new ContainerBuilder();

                        }
                    }
                }
                return _autofacBuilder;
            }
        }

        private static IContainer _autofacContainer;

        public static IContainer AutofacContainer
        {
            get
            {
                if (_autofacContainer == null)
                {
                    lock (lockObj)
                    {
                        if (_autofacContainer == null)
                        {
                            _autofacContainer = _autofacBuilder.Build();

                        }
                    }
                }
                return _autofacContainer;
            }
        }
    }
}
