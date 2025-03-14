# ApiDemo
This project demonstrates multiple bindings in WCF service application, dependency injection of business logic wrapped by the WCF and service contract defined in separate project implemented by business logic services, WCF service and client consuming services. 
There are no "Add service reference" auto-generated classes. All binding are declarative in the web/app.config for the .NET Framework 4.8 projects.
There is also .net 8 client consumer of the service where things are more problematic, there is no WCF, only limited CoreWCF packages.

## Solution structure, projects:
- ### ApiDemo.Contract (.net Standard)
Defines the interfaces used by other projects. By interfaces we mean service interface and model classes, DTO's used by services as input and output parameters.
- ### ApiDemo.Services
Business logic of the services. Implements the interfaces from ApiDemo.Contract. There is no hosting, only service classes.
- ### ApiDemo.Wcf
WCF hosting project of the contracts from ApiDemo.Contract. Acts as plain facade of the services from ApiDemo.Services. No business logic here. Multiple bindings are declared in the web.config for the same contract. Currently REST, SOAP and named pipes. More can be added.
Binding can be commented in or out in order to enable them or disable. netTcpBinding might colide with other ones.
- ### ApiDemo.Client.NET48
Typical WCF consumer client. No generated proxy classes from WSDL. All bindings are based on the configuration (URL, binding type), contract from the shared project ApiDemo.Contract. Client classes are implementations of the shared interface and ClientBase<shared interface>. This is the traditional and "proper" way to go when creating clients for WCFservices programmatically.
- ### ApiDemo.Client.net8
Client in .net 8. In .net 8 and .net Core, there is no WCF. We can use gRPC for named pipes, SOAP and RESTfull bindings in WebAPI or WCF port named CoreWCF. This project uses CoreWCF bindings. There is no "ready-to-use" configuration from the appsettings.json file. We might need to implement our own or use programmatic way, which is the way this project works.
Currently named pipes binding is not working (probably not implemented) as well as well net.TCP binding (but this is probably just configuration issue)

## How to run and test?
- Run the WCF project to get the WCF host running. Comment in or out the bindings which should be tested.
- From another VS or from console run the clients .NET48 or .net8 to see them connect. Again, turn on or off binding in the app.config
- To test WCS REST binding: comment-in [WebGet line inside ApiDemo.Wcf.TestService, the you can connect to the URL via browser "GET".
- Any other means such as PostMan
