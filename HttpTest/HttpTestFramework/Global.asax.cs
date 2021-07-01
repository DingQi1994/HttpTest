using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace HttpTestFramework
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            int workerThreadsMin, completionPortThreadsMin;
            ThreadPool.GetMinThreads(out workerThreadsMin, out completionPortThreadsMin);
            int workerThreadsMax, completionPortThreadsMax;
            ThreadPool.GetMaxThreads(out workerThreadsMax, out completionPortThreadsMax);

            // Adjust min threads
            ThreadPool.SetMinThreads(workerThreadsMax, completionPortThreadsMin);
           
        }
    }
}
