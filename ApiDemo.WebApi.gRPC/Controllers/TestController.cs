using ApiDemo.Contract.Model;
using ApiDemo.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.WebApi.gRPC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController: ControllerBase, ITestService
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [HttpGet("GetMessage")]
        public string GetMessage(string input)
        {
            return testService.GetMessage(input);
        }

        [HttpPost("SaveMessage")]
        public SaveMessageResponse SaveMessage(SaveMessageRequest request)
        {
            return testService.SaveMessage(request);
        }
    }
}
