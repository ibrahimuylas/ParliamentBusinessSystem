using System;
using System.Collections.Generic;

namespace PBS.Domain.Models
{
    public class EventDetailsModel
    {
        public string Category { get; set; }

        public List<MemberModel> Members { get; set; }
    }
}
