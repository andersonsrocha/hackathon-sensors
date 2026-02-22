using HackathonSensors.Application.RabbitMQ.Handlers;
using HackathonSensors.Application.RabbitMQ.Interfaces;
using HackathonSensors.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

#region [RabbitMQ]
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
#endregion

var host = builder.Build();
host.Run();