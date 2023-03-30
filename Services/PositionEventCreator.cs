using System.Data;
using WebApplication3.Interfaces;
using WebApplication3.Proto;

namespace WebApplication3
{
    internal class PositionEventCreator : IEventCreator<Position>
    {
        public PositionEventCreator()
        {
        }

        public IEnumerable<IMessage> CreateEvents(DataTable dataSet, ICacheService<Position> cache)
        {
            var events = new List<IMessage>();

            foreach (DataRow row in dataSet.Rows)
            {
                if (cache.TryGet("x", out _))
                {
                    continue;
                }

                var deviceId = Guid.NewGuid().ToString();
                var @event = new Provision(deviceId, row[0].ToString(), row[1].ToString());

                events.Add(@event);
                cache.Add(deviceId, @event.SourceId);
            }

            return events;
        }
    }
}