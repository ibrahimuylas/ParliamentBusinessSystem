using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBS.Core.Service.External;
using PBS.Core.Toolkit;
using PBS.Core.Toolkit.Configuration;
using PBS.Domain.External;
using PBS.Toolkit;

namespace PBS.Service.External
{
    public class EventService : ExternalServiceBase, IEventService
    {
        private readonly IAPISettings _settings;

        internal override ServiceResponseTypes ResponseTypes => ServiceResponseTypes.Json;

        internal override string APIUrl => _settings.GetEventServiceUrl();

        public EventService(IAPISettings settings, IPBSClient client) : base(client)
        {
            _settings = settings;
        }

        public async Task<IList<Event>> GetEventsAsync(DateTime startDate, DateTime endDate)
        {
            var result = await GetData<List<Event>>($"queryParameters.startDate={startDate.ToString("yyyy-MM-dd")}&queryParameters.endDate={endDate.ToString("yyyy-MM-dd")}");
            return result?? new List<Event>();
        }

        public async Task<Event> GetEventByIdAsync(DateTime startDate, DateTime endDate, int id)
        {
            var result = await GetData<List<Event>>($"queryParameters.startDate={startDate.ToString("yyyy-MM-dd")}&queryParameters.endDate={endDate.ToString("yyyy-MM-dd")}&&queryParameters.eventId={id}");
            return result != null && result.Count() > 0 ? result[0] : new Event();
        }

    }
}
