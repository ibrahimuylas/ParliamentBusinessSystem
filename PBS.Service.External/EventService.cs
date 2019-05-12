using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
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
            var result = new List<Event>();
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

        public async Task<Event> GetEventByIdAsync(DateTime startDate, DateTime endDate, int id)
        {
            var result = new List<Event>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://service.calendar.parliament.uk/calendar/events/list.json?queryParameters.startDate={startDate.ToString("yyyy-MM-dd")}&queryParameters.endDate={endDate.ToString("yyyy-MM-dd")}&&queryParameters.eventId={id}");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<Event>>(await response.Content.ReadAsStringAsync());
                }
            }
            return result != null && result.Count() > 0 ? result[0] : new Event();
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            List<Member> result = null;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new XmlSerializer(typeof(List<Member>), new XmlRootAttribute("Members"));
                    StringReader stringReader = new StringReader(await response.Content.ReadAsStringAsync());
                    result = (List<Member>)serializer.Deserialize(stringReader);
                }
            }
            return result != null && result.Count() > 0 ? result[0] : new Member();
        }
    }
}
