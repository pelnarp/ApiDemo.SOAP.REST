using ApiDemo.Contract.Model;
using ApiDemo.Contract.Services;
using System;
using System.ServiceModel.Web;

namespace ApiDemo.Wcf
{
    public class TestService : ITestService
    {
        private readonly ITestService testService;

        public TestService(ITestService testService)
        {
            this.testService = testService ?? throw new ArgumentNullException(nameof(testService));
        }

        // [WebGet(UriTemplate = "GetMessage/{input}", ResponseFormat = WebMessageFormat.Json)] Uncomment this to change the contract to GET on the give URL
        public string GetMessage(string input)
        {
            return testService.GetMessage(input);
        }

        [WebInvoke(Method = "POST", UriTemplate = "/SaveMessage", RequestFormat = WebMessageFormat.Json)]
        public SaveMessageResponse SaveMessage(SaveMessageRequest request)
        {
            return testService.SaveMessage(request);
        }
    }
}