using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PBS.Core.Service.External;
using PBS.Domain.External;

namespace PBS.Service.External
{
    public class EventService : IEventService
    {

        public EventService()
        {
        }

        public async Task<IList<Event>> GetEventsAsync(DateTime startDate, DateTime endDate)
        {
            List<Event> result = new List<Event>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://service.calendar.parliament.uk/calendar/events/list.json?queryParameters.startDate={startDate.ToString("yyyy-MM-dd")}&queryParameters.endDate={endDate.ToString("yyyy-MM-dd")}");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<Event>>(await response.Content.ReadAsStringAsync());
                }
            }
            return result;
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            Event result = null;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://service.calendar.parliament.uk/calendar/events/list.json?queryParameters.id={id}");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync());
                }
            }
            return result;
        }
    }
}
