using HackathonSensors.Application.RabbitMQ.Commands;
using HackathonSensors.Application.RabbitMQ.Interfaces;

namespace HackathonSensors.WorkerService;

public class Worker(IRabbitMqService service, IConfiguration configuration, ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (Guid.TryParse(configuration["PlotId"], out var plotId))
            {
                logger.LogInformation("Reading data for plot {PlotId}", plotId);
                var reading = new ReadingRequest
                {
                    PlotId = plotId,
                    Date = DateTime.Now,
                    SoilMoisture = Random.Shared.NextDouble() * 100,
                    Temperature = 15 + Random.Shared.NextDouble() * 20,
                    Precipitation = Random.Shared.NextDouble() * 10
                };
                
                await service.SendPurchaseAsync(reading);
            }

            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}