using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PBS.Core.Helper;
using PBS.Core.Service;
using PBS.Core.Service.External;
using PBS.Domain.External;
using PBS.Domain.Models;

namespace PBS.Service
{
    public class BusinessService : IBusinessService
    {
        private readonly IEventService _eventService;
        private IMapper _mapper;
        private IDateTimeHelper _dateTimeHelper;

        public BusinessService(IMapper mapper, IEventService eventService, IDateTimeHelper dateTimeHelper)
        {
            _eventService = eventService;
            _mapper = mapper;
            _dateTimeHelper = dateTimeHelper;
        }

        public async Task<IList<EventModel>> GetEventsAsync(string value)
        {
            var date = _dateTimeHelper.GetDateTime(value);
            var startDate = _dateTimeHelper.GetFirstDayOfWeek(date);
            var endDate = _dateTimeHelper.GetLastDayOfWeek(date);

            var events = await _eventService.GetEventsAsync(startDate, endDate);

            return _mapper.Map<List<Event>, List<EventModel>>(events.ToList());
        }

        public async Task<EventDetailsModel> GetEventDetailsAsync(string value, int id)
        {
            var date = _dateTimeHelper.GetDateTime(value);
            var startDate = _dateTimeHelper.GetFirstDayOfWeek(date);
            var endDate = _dateTimeHelper.GetLastDayOfWeek(date);

            var model = new EventDetailsModel();
            var e = await _eventService.GetEventByIdAsync(startDate, endDate, id);
            model.Category = e?.Category;

            model.Members = _mapper.Map<List<EventMember>, List<MemberModel>>(e?.Members);

            if (model.Members?.Count() > 0)
            {
                foreach (var m in model.Members)
                {
                    var result = await _eventService.GetMemberByIdAsync(m.Id);
                    m.FullTitle = result.FullTitle;
                    m.MemberFrom = result.MemberFrom;
                    m.Party = result.Party?.Text;
                }
            }

            return model;
        }

    }
}
