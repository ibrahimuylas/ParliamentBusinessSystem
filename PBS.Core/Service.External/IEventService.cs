using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBS.Domain.External;

namespace PBS.Core.Service.External
{
    public interface IEventService
    {
        Task<IList<Event>> GetEventsAsync(DateTime startDate, DateTime endDate);

        Task<Event> GetEventByIdAsync(int id);
    }
}
