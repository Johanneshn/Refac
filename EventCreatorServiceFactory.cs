//using WebApplication3.Infrastructure;
//using WebApplication3.Interfaces;
//using WebApplication3.Models;

//namespace WebApplication3;

//public class EventCreatorServiceFactory : IEventCreatorServiceFactory
//{
//    private readonly IEventBusPublisher eventBusPublisher;
//    private readonly ICursorService cursorService;
//    private readonly ICacheService deviceCache;

//    public EventCreatorServiceFactory(IEventBusPublisher eventBusPublisher, ICursorService cursorService)
//    {
//        this.eventBusPublisher = eventBusPublisher;
//        this.cursorService = cursorService;

//        deviceCache = new DeviceCache();
//    }

//    public IEventBaseService CreateDeviceService()
//    {
//        Console.WriteLine("Factory, created CreateDeviceService");

//        var reader = new PositionReader();
//        var eventCreator = new DeviceEventCreator();
//        var cache = new RegistryCache(deviceCache);

//        return new EventBaseService(reader, eventBusPublisher, eventCreator, cursorService, deviceCache, "device");
//    }

//    public IEventBaseService CreateRegistryService()
//    {
//        //
//        throw new NotImplementedException();
//    }
//}

//public interface IEventCreatorServiceFactory
//{
//    IEventBaseService CreateDeviceService();

//    IEventBaseService CreateRegistryService();
//}