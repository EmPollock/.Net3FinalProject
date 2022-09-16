using DataAccessFakes;
using LogicLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresntationLayer.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            // live
            kernel.Bind<ICritterManager>().To<LogicLayer.CritterManager>();
            kernel.Bind<IBugManager>().To<LogicLayer.BugManager>();
            kernel.Bind<IFishManager>().To<LogicLayer.FishManager>();
            kernel.Bind<ISeaCreatureManager>().To<LogicLayer.SeaCreatureManager>();
            kernel.Bind<IUserManager>().To<LogicLayer.UserManager>();

            // fake
            //kernel.Bind<ICritterManager>().To<LogicLayer.CritterManager>().WithConstructorArgument("critterAccessor", new CritterAccessorFake()).WithConstructorArgument("userAccessor", new UserAccessorFake());
            //kernel.Bind<IBugManager>().To<LogicLayer.BugManager>().WithConstructorArgument("bugAccessor", new BugAccessorFake());
            //kernel.Bind<IFishManager>().To<LogicLayer.FishManager>().WithConstructorArgument("fishAccessor", new FishAccessorFake());
            //kernel.Bind<ISeaCreatureManager>().To<LogicLayer.SeaCreatureManager>().WithConstructorArgument("seaCreatureAccessor", new SeaCreatureAccessorFake());
            //kernel.Bind<IUserManager>().To<LogicLayer.UserManager>().WithConstructorArgument("userManager", new UserAccessorFake());
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}