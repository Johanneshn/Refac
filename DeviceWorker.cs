﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using WebApplication3;
using WebApplication3.Infrastructure;
using WebApplication3.Proto;

public class DeviceWorker : BackgroundService
{
    private readonly IEventBaseService<Provision> deviceEventService;

    public DeviceWorker(IEventBaseService<Provision> eventBaseService)
    {
        deviceEventService = eventBaseService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await deviceEventService.Execute();
            await Task.Delay(1000);
        }
    }
}