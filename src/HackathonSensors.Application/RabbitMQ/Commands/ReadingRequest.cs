namespace HackathonSensors.Application.RabbitMQ.Commands;

public sealed class ReadingRequest
{
    public Guid PlotId { get; set; } = Guid.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public double SoilMoisture { get; set; } = 0.0;
    public double Temperature { get; set; } = 0.0;
    public double Precipitation { get; set; } = 0.0;
}