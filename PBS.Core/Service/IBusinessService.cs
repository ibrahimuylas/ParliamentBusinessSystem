using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBS.Domain.Models;

namespace PBS.Core.Service
{
    public interface IBusinessService
    {
        Task<IList<EventModel>> GetEventsAsync(string value);

        Task<EventDetailsModel> GetEventDetailsAsync(string value, int id);
    }
}
