using AISV1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISV1.Data
{
    public class AISContext : DbContext
    {
        public AISContext(DbContextOptions<AISContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<FileCustomer> FileCustomers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileRemark> FileRemarks { get; set; }
        public DbSet<EventType> EventType { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<FileCustomer>().ToTable("FileCustomer");
            modelBuilder.Entity<File>().ToTable("File");
            modelBuilder.Entity<FileRemark>().ToTable("FileRemark");
            modelBuilder.Entity<EventType>().ToTable("EventType");
        }
  
    }
}
