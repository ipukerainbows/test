using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISV1.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string AmountGuests { get; set; }
        public string AmountAdults{ get; set; }
        public string AmountChildren{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
