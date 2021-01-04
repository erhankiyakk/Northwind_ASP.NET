using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Northwind.Bll.Concrete;
using Northwind.CrossCuttingConcerns.Logging;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.MvcWebUI.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        IKernel kernal;
        public NinjectControllerFactory()
        {
            kernal = new StandardKernel();
            AddBllBinding();
            //AddServiceBinding();
        }

        private void AddBllBinding()
        {
            kernal.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("_productDal",new EfProductDal());
           
            kernal.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
            
            kernal.Bind<IAuthenticationService>().To<AuthenticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());

            //kernal.Intercept(p => (true)).With(new LoggingInterceptor());
           
        }
        private void AddServiceBinding()
        {
            kernal.Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
            kernal.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());
            kernal.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernal.Get(controllerType);
        }
    }
}