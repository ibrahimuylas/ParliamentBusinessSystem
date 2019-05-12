using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBS.Core.Service;
using PBS.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PBS.API.Controllers
{
    [Route("api/")]
    public class BusinessController : Controller
    {
        private readonly IBusinessService _service;

        public BusinessController(IBusinessService service)
        {
            _service = service;
        }

        [HttpGet("GetEvents/{date}")]
        public async Task<IList<EventModel>> GetEventsAsync(string date)
        {
            return await _service.GetEventsAsync(date);
        }

        [HttpGet("GetEventDetails/{date}/{id}")]
        public async Task<EventDetailsModel> GetEventDetailsAsync(string date, int id)
        {
            return await _service.GetEventDetailsAsync(date, id);
        }

    }
}
