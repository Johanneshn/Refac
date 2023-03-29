using WebApplication3.Infrastructure;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3;

public class EventCreatorServiceFactory : IEventCreatorServiceFactory
{
    private readonly IEventBusPublisher eventBusPublisher;
    private readonly ICursorService cursorService;

    public EventCreatorServiceFactory(IEventBusPublisher eventBusPublisher, ICursorService cursorService)
    {
        this.eventBusPublisher = eventBusPublisher;
        this.cursorService = cursorService;
    }

    public IEventBaseService CreateDeviceService()
    {
        Console.WriteLine("Factory, created CreateDeviceService");

        var reader = new DeviceCertReader();
        var eventCreator = new DeviceEventCreator();
        var cache = new DeviceCache();

        return new EventBaseService(reader, eventBusPublisher, eventCreator, cursorService, cache, "device");
    }

    public IEventBaseService CreateRegistryService()
    {
        throw new NotImplementedException();
    }
}

public interface IEventCreatorServiceFactory
{
    IEventBaseService CreateDeviceService();

    IEventBaseService CreateRegistryService();
}