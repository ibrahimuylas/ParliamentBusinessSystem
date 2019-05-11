using System;
using AutoMapper;
using PBS.Domain.External;
using PBS.Domain.Models;

namespace PBS.Service
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Event, EventModel>();

        }
    }
}
