using System.Data;
using WebApplication3.Interfaces;

namespace WebApplication3
{
    internal class DeviceEventCreator : IEventCreator
    {
        public DeviceEventCreator()
        {
        }

        public IEnumerable<IMessage> CreateEvents(DataTable dataSet, ICacheService cache)
        {
            var events = new List<IMessage>();

            foreach (DataRow row in dataSet.Rows)
            {
                if (cache.TryGet("x", out _))
                {
                    continue;
                }

                var deviceId = Guid.NewGuid().ToString();
                var @event = new DeviceProvisionedEvent(deviceId, row[0].ToString(), row[1].ToString());

                events.Add(@event);
                cache.Add(deviceId, @event.SourceId);
            }

            return events;
        }
    }
}