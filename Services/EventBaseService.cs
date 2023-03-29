using WebApplication3.Interfaces;

namespace WebApplication3
{
    public class EventBaseService : IEventBaseService
    {
        private readonly ICertReader reader;
        private readonly IEventBusPublisher publisher;
        private readonly IEventCreator eventCreator;
        private readonly ICursorService cursor;
        private readonly ICacheService cache;
        private readonly string serviceName;
        private readonly string cursorKey;

        public EventBaseService(ICertReader reader, IEventBusPublisher publisher, IEventCreator eventCreator,
            ICursorService cursor, ICacheService cache, string serviceName)
        {
            this.reader = reader;
            this.publisher = publisher;
            this.eventCreator = eventCreator;
            this.cursor = cursor;
            this.cache = cache;
            this.serviceName = serviceName;
            cursorKey = $"{serviceName}Cursor";
        }

        public async Task Execute()
        {
            if (!cache.IsSynced())
            {
                await cache.Sync();
                return;
            }

            var currentCursor = cursor.GetCursor(cursorKey);
            var readRows = await reader.BatchReadNext(currentCursor);

            var events = eventCreator.CreateEvents(readRows.Data);

            foreach (var @event in events)
            {
                publisher.Publish(@event);
            }

            if (events.Any())
            {
                Console.WriteLine($"{serviceName} published {events.Count()} events");
                cursor.SaveCursor(cursorKey, readRows.NewCursorPosition);
                Console.WriteLine($"{serviceName} updated cursor to: {readRows.NewCursorPosition}");
            }
        }
    }
}