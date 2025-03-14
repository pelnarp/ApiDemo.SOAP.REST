using ApiDemo.Contract.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace ApiDemo.Client.NET48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create the Windsor Container
            var container = new WindsorContainer();

            // Step 2: Register Components (Classes to inject)
            container.Register(Component.For<ITestService>()
                .ImplementedBy<Services.TestService>()
                .LifestyleSingleton());

            // Step 3: Resolve and use the service
            var testService = container.Resolve<ITestService>();

            // Step 4: Call the service method
            Console.WriteLine(testService.GetMessage("Hello to named WCF service"));

            // Clean up and release the container
            container.Release(testService);

            Console.WriteLine("DONE");

            Console.ReadKey();
        }
    }
}
