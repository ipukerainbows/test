using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AISV2.Models
{
    public class ContactPerson
    {
        public int ContactPersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        public ICollection<FileContactPerson> FileContactPerson { get; set; }
    }
}
