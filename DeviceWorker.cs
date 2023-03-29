using WebApplication3;

public class DeviceWorker : BackgroundService
{
    private readonly IEventBaseService eventCreatorService;

    public DeviceWorker(EventCreatorServiceFactory factory)
    {
        eventCreatorService = factory.CreateDeviceService();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await eventCreatorService.Execute();
            await Task.Delay(1000);
        }
    }
}