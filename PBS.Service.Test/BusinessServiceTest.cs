using System;
using Moq;
using Xunit;
using PBS.Service;
using AutoMapper;
using PBS.Core.Service.External;
using PBS.Core.Helper;
using System.Linq;
using PBS.Toolkit;
using PBS.Service.External;
using PBS.Toolkit.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PBS.Service.Test
{
    public class BusinessServiceTest
    {
        [Fact]
        public async System.Threading.Tasks.Task EventsAsync()
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var apiSetting = new APISettings(configuration);
            var pbsClient = new PBSClient();

            var eventService = new EventService(apiSetting,pbsClient );
            var memberService = new MemberService(apiSetting, pbsClient);
            var dateTimeHelper = new DateTimeHelper();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var businessService = new BusinessService(mapper, eventService, memberService, dateTimeHelper);

            Assert.NotNull(businessService);

            var eventList = await businessService.GetEventsAsync("2019-05-11");

            Assert.NotNull(eventList);
            Assert.NotEmpty(eventList);

            Assert.Equal(0, eventList.Count(x => x.StartDate < new DateTime(2019, 5, 6)));
            Assert.Equal(0, eventList.Count(x => x.EndDate > new DateTime(2019, 5, 12)));

        }

        [Fact]
        public async System.Threading.Tasks.Task EventDetailsAsync()
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();
            var apiSetting = new APISettings(configuration);
            var pbsClient = new PBSClient();

            var eventService = new EventService(apiSetting, pbsClient);
            var memberService = new MemberService(apiSetting, pbsClient);
            var dateTimeHelper = new DateTimeHelper();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var businessService = new BusinessService(mapper, eventService, memberService, dateTimeHelper);

            Assert.NotNull(businessService);

            var eventList = await businessService.GetEventDetailsAsync("2019-05-13", 26788);

            Assert.NotNull(eventList);
            Assert.NotEmpty(eventList.Members);
            Assert.Single(eventList.Members);

            Assert.Equal("Business Statement", eventList.Category);
            Assert.Equal("Rt Hon Andrea Leadsom MP", eventList.Members[0].FullTitle);

        }
    }
}
