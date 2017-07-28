using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DashBoard.Models.Interface;
using DashBoard.Models.Operation;
using Ninject;

namespace DashBoard.Infractructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
           requestContext, Type controllerType)
        {

            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IContractRenew>().To<ContractRenew>();
            ninjectKernel.Bind<IInvoice>().To<Invoice>();
            ninjectKernel.Bind<IForecast>().To<Forecast>();
        }
    }
}