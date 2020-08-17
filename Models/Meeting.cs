using AISV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISV2.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public int FileID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime CreationTime { get; set; }
        public File File { get; set; }
    }
}
