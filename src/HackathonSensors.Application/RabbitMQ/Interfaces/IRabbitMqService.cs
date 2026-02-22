using OperationResult;
using HackathonSensors.Application.RabbitMQ.Commands;

namespace HackathonSensors.Application.RabbitMQ.Interfaces;

public interface IRabbitMqService
{
    Task<Result> SendPurchaseAsync(ReadingRequest request);
}