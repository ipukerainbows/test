using System.Collections.Generic;

namespace AISV1.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }

        public ICollection<FileCustomer> FileCustomers { get; set; }
    }
}