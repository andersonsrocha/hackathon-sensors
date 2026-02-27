using HackathonSensors.Application.RabbitMQ.Handlers;
using HackathonSensors.Application.RabbitMQ.Interfaces;
using HackathonSensors.WorkerService;
using HackathonSensors.WorkerService.Configurations;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

#region [RabbitMQ]
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
#endregion

#region [Serilog]
builder.AddSerilog();
#endregion

var host = builder.Build();
host.Run();