using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.CrossCuttingConcerns.Logging
{
    public class LoggingInterceptor: SimpleInterceptor
    {
        protected override void BeforeInvoke(IInvocation invocation)
        {
            //Loglama frameworkünün loglama işlemi yapılacak
            base.BeforeInvoke(invocation);
        }
        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);
        }

    }
}
