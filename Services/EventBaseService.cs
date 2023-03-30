using Microsoft.AspNetCore.SignalR;
using WebApplication3.Interfaces;

namespace WebApplication3
{
    public class EventBaseService<T> : IEventBaseService<T>
    {
        private readonly ICertReader<T> reader;
        private readonly IEventBusPublisher publisher;
        private readonly IEventCreator<T> eventCreator;
        private readonly ICursorService cursor;
        private readonly ICacheService<T> cache;
        private readonly string serviceName = typeof(T).Name;
        private readonly string cursorKey;

        public EventBaseService(ICertReader<T> reader, IEventBusPublisher publisher, IEventCreator<T> eventCreator,
            ICursorService cursor, ICacheService<T> cache)
        {
            this.reader = reader;
            this.publisher = publisher;
            this.eventCreator = eventCreator;
            this.cursor = cursor;
            this.cache = cache;
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

            var events = eventCreator.CreateEvents(readRows.Data, cache);

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