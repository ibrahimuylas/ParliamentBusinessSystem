using System;
using System.Collections.Generic;

namespace PBS.Domain.External
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int SortOrder { get; set; }
        public string Type { get; set; }
        public string House { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string LocationMetadata { get; set; }
        public bool HasSpeakers { get; set; }
        //public Committee Committee { get; set; }
        //public List<Tag> Tags { get; set; }
        public List<Member> Members { get; set; }
        //public List<Metadata> Metadata { get; set; }
        public string SummarisedDetails { get; set; }
    }
}
