using ApiDemo.Contract.Services;
using System.ServiceModel;

public class Program
{
    public const int HTTP_PORT = 8000;
    public const int HTTPS_PORT = 8000;
    public const int NETTCP_PORT = 8000;

    static async Task Main(string[] args)
    {
        Console.Title = "WCF .Net Core Client";

        //await CallBasicHttpBinding();
        await CallNetTcpBinding();
    }

    private static async Task CallBasicHttpBinding()
    {
        var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);

        var factory = new ChannelFactory<ITestService>(binding, new EndpointAddress($"http://localhost:8000/TestService/soap"));
        factory.Open();
        try
        {
            ITestService client = factory.CreateChannel();
            var channel = client;
            var result = client.GetMessage("Hello from .net 8 client!");
            Console.WriteLine(result);
        }
        finally
        {
            factory.Close();
        }
    }


    private static async Task CallNetTcpBinding()
    {
        var binding = new NetTcpBinding();

        var factory = new ChannelFactory<ITestService>(binding, new EndpointAddress($"net.tcp://localhost:8001/TestService"));
        factory.Open();
        try
        {
            ITestService client = factory.CreateChannel();
            var result = client.GetMessage("Hello World!");
            Console.WriteLine(result);
        }
        finally
        {
            factory.Close();
        }
    }

    private static bool IsHttps(string url)
    {
        return url.ToLower().StartsWith("https://");
    }
}
