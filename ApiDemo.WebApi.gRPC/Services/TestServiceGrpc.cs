using ApiDemo.Contract.Model;
using ApiDemo.Contract.Services;
using ApiDemo.Services.NetCore.Services;

namespace ApiDemo.WebApi.gRPC.Services
{
    public class TestServiceGrpc: ITestService
    {
        private readonly ITestService testService;

        public TestServiceGrpc(ITestService testService)
        {
            this.testService = testService;
        }

        public string GetMessage(string input)
        {
            return testService.GetMessage(input);
        }

        public SaveMessageResponse SaveMessage(SaveMessageRequest request)
        {
            return testService.SaveMessage(request);
        }
    }
}
