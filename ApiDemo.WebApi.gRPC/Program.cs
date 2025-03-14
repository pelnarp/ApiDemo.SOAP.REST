using ApiDemo.Contract.Services;
using ApiDemo.Services.Services;
using ApiDemo.WebApi.gRPC.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();  // gRPC for Named Pipes
builder.Services.AddControllers(); // REST API
builder.Services.AddSoapCore();
builder.Services.AddSingleton<ITestService, TestService>();

var app = builder.Build();

app.UseRouting();

app.UseSoapEndpoint<ITestService>("/soap", new SoapEncoderOptions());

// REST
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // REST API
    endpoints.MapGrpcService<TestServiceGrpc>(); // gRPC
});

app.MapGrpcService<TestServiceGrpc>();

app.Run();
