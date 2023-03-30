using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using WebApplication3;
using WebApplication3.Infrastructure;
using WebApplication3.Proto;

public class PositionWorker : BackgroundService
{
    private readonly IEventBaseService<Position> eventService;

    public PositionWorker(IEventBaseService<Position> eventBaseService)
    {
        eventService = eventBaseService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await eventService.Execute();
            await Task.Delay(1000);
        }
    }
}