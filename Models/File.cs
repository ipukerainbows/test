using AISV2.Models;
using System;
using System.Collections.Generic;

namespace AISV1.Models
{
    public class File
    {
        public int FileId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ArrivalOfOrganisers { get; set; }
        public int AmountOfPeople { get; set; }
        public int AmountOfPeopleReception { get; set; }
        public int AmountOfPeopleDiningEst { get; set; }
        public int AmountOfPeopleDesertEst { get; set; }

        public ICollection<FileCustomer> FileCustomers { get; set; }
        public ICollection<FileRemark> FileRemarks { get; set; }
        public ICollection<FileContactPerson> FileContactPerson { get; set; }
        public ICollection<Meeting> Meetings { get; set; }

        public EventType EventType { get; set; }
    }
}
