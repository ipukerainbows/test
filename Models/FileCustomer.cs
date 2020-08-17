using System.Collections.Generic;

namespace AISV1.Models
{
    public class FileCustomer
    {
        public int FileCustomerID { get; set; }
        public int FileID { get; set; }
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        public File File { get; set; }
    }
}