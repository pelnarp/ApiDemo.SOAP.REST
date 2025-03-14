﻿using ApiDemo.Contract.Model;
using System.ServiceModel;

namespace ApiDemo.Contract.Services
{
    // Service contract (SOAP & REST)
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string GetMessage(string name);

        [OperationContract]
        SaveMessageResponse SaveMessage(SaveMessageRequest request);
    }
}
