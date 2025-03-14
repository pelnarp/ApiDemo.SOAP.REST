using ApiDemo.Contract.Model;
using ApiDemo.Contract.Services;
using System;

namespace ApiDemo.Services.Services
{
    public class TestService : ITestService
    {
        static int responseCount = 0;

        public string GetMessage(string input)
        {
            return $"Response message to request: {input}, time: {DateTime.UtcNow.ToString()}";
        }

        public SaveMessageResponse SaveMessage(SaveMessageRequest request)
        {
            return new SaveMessageResponse
            {
                ResultSet = responseCount
            };
        }
    }
}
