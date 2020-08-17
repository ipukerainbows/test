using AISV1.Models;

namespace AISV2.Models
{
    public class FileContactPerson
    {
        public int FileContactPersonID { get; set; }
        public int FileID { get; set; }
        public int ContactPersonID { get; set; }

        public ContactPerson ContactPerson { get; set; }
        public File File { get; set; }
    }
}