using ApiDemo.Contract.Model;
using ApiDemo.Contract.Services;
using System.ServiceModel;

namespace ApiDemo.Client.NET48.Services
{
    public class TestService : ClientBase<ITestService>, ITestService
    {
        public string GetMessage(string input)
        {
            return Channel.GetMessage(input);
        }

        public SaveMessageResponse SaveMessage(SaveMessageRequest request)
        {
            return Channel.SaveMessage(request);
        }
    }
}
