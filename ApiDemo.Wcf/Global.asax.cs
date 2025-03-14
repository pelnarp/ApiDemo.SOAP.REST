using System;
using System.Web;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Facilities.WcfIntegration;
using ApiDemo.Contract.Services;

namespace ApiDemo.Wcf
{
    public class Global : HttpApplication
{
    public static IWindsorContainer Container;

    protected void Application_Start(object sender, EventArgs e)
    {
        Container = new WindsorContainer();
        Container.AddFacility<WcfFacility>(); // Enables WCF integration

        // Register business logic service from .NET Standard project
        Container.Register(Component.For<ITestService>().ImplementedBy<Services.Services.TestService>().LifestyleTransient());

        // Register WCF service with Windsor
        Container.Register(Component.For<ITestService>()
            .ImplementedBy<TestService>()
            .AsWcfService()
            .LifestylePerWcfOperation());
    }

    protected void Application_End(object sender, EventArgs e)
    {
        Container.Dispose();
    }
}

    }