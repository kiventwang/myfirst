using Autofac;
using TestInterfaceTool.ContainerManager;
using TestInterfaceTool.Core.FillData;
using System.Collections.Generic;

namespace TestInterfaceTool.Services
{
    public class ServiceInformationBase : IServicesInformation
    {



        public Dictionary<string, Core.Model.ServerPathModel> GetServerPath()
        {
            return LoadRespository<IRespository>().GetServerPath();
        }



        public Dictionary<string, Core.Model.RealInterfaceInfoModel> GetInterfaceName()
        {
            return LoadRespository<IRespository>().GetInterfaceName();
        }





        protected virtual TRepository LoadRespository<TRepository>() where TRepository:IRespository
        {
            var container = AutofacContainerManager.AutofacContainer;
            return container.Resolve<TRepository>();
        }


        public Dictionary<string, Core.Model.SortNameModel> GetSortName()
        {
            return LoadRespository<IRespository>().GetSortName();
        }
    }
}
