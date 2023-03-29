using System.Data;
using WebApplication3.Interfaces;

namespace WebApplication3
{
    internal class DeviceEventCreator : IEventCreator
    {
        public DeviceEventCreator()
        {
        }

        public IEnumerable<IMessage> CreateEvents(DataTable dataSet)
        {
            var events = new List<IMessage>();

            foreach (DataRow row in dataSet.Rows)
            {
                var deviceId = Guid.NewGuid().ToString();
                var @event = new DeviceProvisionedEvent(deviceId, row[0].ToString(), row[1].ToString());
                events.Add(@event);
            }

            return events;
        }
    }
}