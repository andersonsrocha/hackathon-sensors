using HackathonSensors.Application.RabbitMQ.Commands;
using HackathonSensors.Application.RabbitMQ.Interfaces;

namespace HackathonSensors.WorkerService;

public class Worker(IRabbitMqService service, IConfiguration configuration, ILogger<Worker> logger) : BackgroundService
{
    private readonly Guid _plotId = Guid.Parse(configuration["PlotId"] ?? string.Empty);
    private readonly int _delayInSeconds = int.Parse(configuration["DelayInSeconds"] ?? "10");

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Reading data for plot {PlotId}", _plotId);
            var reading = new ReadingRequest
            {
                PlotId = _plotId,
                Date = DateTime.Now,
                SoilMoisture = Random.Shared.NextDouble() * 100,
                Temperature = 15 + Random.Shared.NextDouble() * 20,
                Precipitation = Random.Shared.NextDouble() * 10
            };

            await service.SendPurchaseAsync(reading);

            await Task.Delay(TimeSpan.FromSeconds(_delayInSeconds), stoppingToken);
        }
    }
}