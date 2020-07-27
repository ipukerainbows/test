using AISV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISV1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AISContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Files.
            if (context.Files.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
               new Customer{Name = "Customer 1"},
               new Customer{Name = "Customer 2"},
               new Customer{Name = "Customer 3"},
               new Customer{Name = "Customer 4"}
            };

            foreach (Customer C in customers)
            {
                context.Customers.Add(C);
            }
            context.SaveChanges();


            var eventType = new EventType[]
             {
                new EventType{Description="Huwelijk"},
                new EventType{Description="Personeelsfeest"},
                new EventType{Description="BabyBorrel"},
                new EventType{Description="Seminary"},
                new EventType{Description="Begrafenis"}
             };

            foreach (EventType et in eventType)
            {
                context.EventType.Add(et);
            }

            var files = new File[]
            {
                new File{Name="TestDossier 1",EventTypeId=1, EventDate=DateTime.Parse("2019-01-01"),StartTime=DateTime.Now, EndTime=DateTime.Now, ArrivalOfOrganisers = DateTime.Now, AmountOfPeople = 10, AmountOfPeopleReception = 10, AmountOfPeopleDiningEst = 20, AmountOfPeopleDesertEst= 50 },
                new File{Name="TestDossier 2",EventTypeId=1, EventDate=DateTime.Parse("2019-01-01"),StartTime=DateTime.Now, EndTime=DateTime.Now, ArrivalOfOrganisers = DateTime.Now, AmountOfPeople = 10, AmountOfPeopleReception = 10, AmountOfPeopleDiningEst = 20, AmountOfPeopleDesertEst= 50 },
                new File{Name="TestDossier 3",EventTypeId=1, EventDate=DateTime.Parse("2019-01-01"),StartTime=DateTime.Now, EndTime=DateTime.Now, ArrivalOfOrganisers = DateTime.Now, AmountOfPeople = 10, AmountOfPeopleReception = 10, AmountOfPeopleDiningEst = 20, AmountOfPeopleDesertEst= 50 },
            };

            foreach (File f in files)
            {
                context.Files.Add(f);
            }

            var fileCustomers = new FileCustomer[]
           {
                   new FileCustomer{CustomerID=1, FileID=1},
                   new FileCustomer{CustomerID=2, FileID=1},
                   new FileCustomer{CustomerID=2, FileID=2},
                   new FileCustomer{CustomerID=3, FileID=1}
           };

            foreach (FileCustomer fc in fileCustomers)
            {
                context.FileCustomers.Add(fc);
            }
            context.SaveChanges();

            var fileRemarks = new FileRemark[]
             {
                 new FileRemark{FileID=1,Remark="test1 - Lorem ipsum"},
                 new FileRemark{FileID=1,Remark="test2 - "},
                 new FileRemark{FileID=1,Remark="test3"},
                 new FileRemark{FileID=1,Remark="test4"},
                 new FileRemark{FileID=1,Remark="test5"}
             };

            foreach (FileRemark fm in fileRemarks)
            {
                context.FileRemarks.Add(fm);
            }
            context.SaveChanges();

       
        }
    }
}
