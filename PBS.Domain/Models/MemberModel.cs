using System;
namespace PBS.Domain.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }

        public string Party { get; set; }
        public string MemberFrom { get; set; }
        public string FullTitle { get; set; }
    }
}
