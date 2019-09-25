using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ContactInformationAPI.IOC
{
    public class DIUnityContainer
    {
        public DIUnityContainer(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IDataModel, DataModel>(new HierarchicalLifetimeManager());
            container.RegisterType<DataAccessLayer.IDataRepository, DataAccessLayer.DataRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDIResolver(container);
        }
    }
}