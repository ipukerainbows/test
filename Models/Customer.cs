﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISV1.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public string VatNumber { get; set; }
        [NotMapped] 
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        public ICollection<FileCustomer> FileCustomers { get; set; }
    }
}