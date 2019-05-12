using System;
using System.Xml.Serialization;

namespace PBS.Domain.External
{
    [XmlRoot(ElementName = "Member")]
    public class Member
    {
        [XmlAttribute(AttributeName = "Clerks_Id")]
        public string Clerks_Id { get; set; }
        //[XmlElement(ElementName = "CurrentStatus")]
        //public CurrentStatus CurrentStatus { get; set; }
        [XmlElement(ElementName = "DateOfBirth")]
        public string DateOfBirth { get; set; }
        //[XmlElement(ElementName = "DateOfDeath")]
        //public DateOfDeath DateOfDeath { get; set; }
        [XmlElement(ElementName = "DisplayAs")]
        public string DisplayAs { get; set; }
        [XmlAttribute(AttributeName = "Dods_Id")]
        public string Dods_Id { get; set; }
        [XmlElement(ElementName = "FullTitle")]
        public string FullTitle { get; set; }
        [XmlElement(ElementName = "Gender")]
        public string Gender { get; set; }
        [XmlElement(ElementName = "House")]
        public string House { get; set; }
        //[XmlElement(ElementName = "HouseEndDate")]
        //public HouseEndDate HouseEndDate { get; set; }
        [XmlElement(ElementName = "HouseStartDate")]
        public string HouseStartDate { get; set; }
        [XmlElement(ElementName = "LayingMinisterName")]
        public string LayingMinisterName { get; set; }
        [XmlElement(ElementName = "ListAs")]
        public string ListAs { get; set; }
        [XmlAttribute(AttributeName = "Member_Id")]
        public string Member_Id { get; set; }
        [XmlElement(ElementName = "MemberFrom")]
        public string MemberFrom { get; set; }
        [XmlElement(ElementName = "Party")]
        public Party Party { get; set; }
        [XmlAttribute(AttributeName = "Pims_Id")]
        public string Pims_Id { get; set; }
    }

    [XmlRoot(ElementName = "Party")]
    public class Party
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    //[XmlRoot(ElementName = "CurrentStatus")]
    //public class CurrentStatus
    //{
    //    [XmlAttribute(AttributeName = "Id")]
    //    public string Id { get; set; }
    //    [XmlAttribute(AttributeName = "IsActive")]
    //    public string IsActive { get; set; }
    //    [XmlElement(ElementName = "Name")]
    //    public string Name { get; set; }
    //    [XmlElement(ElementName = "Reason")]
    //    public string Reason { get; set; }
    //    [XmlElement(ElementName = "StartDate")]
    //    public string StartDate { get; set; }
    //}

    //[XmlRoot(ElementName = "DateOfDeath")]
    //public class DateOfDeath
    //{
    //    [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    //    public string Nil { get; set; }
    //    [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
    //    public string Xsi { get; set; }
    //}

    //[XmlRoot(ElementName = "HouseEndDate")]
    //public class HouseEndDate
    //{
    //    [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    //    public string Nil { get; set; }
    //    [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
    //    public string Xsi { get; set; }
    //}

}
