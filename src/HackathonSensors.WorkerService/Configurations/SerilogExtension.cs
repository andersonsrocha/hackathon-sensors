using NewRelic.LogEnrichers.Serilog;
using Serilog;
using Serilog.Events;

namespace HackathonSensors.WorkerService.Configurations;

public static class SerilogExtension
{
    public static void AddSerilog(this HostApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.WithNewRelicLogsInContext()
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {CorrelationId}] {Message}{NewLine}{Exception}")
            .CreateLogger();
        
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(Log.Logger);
    }
}