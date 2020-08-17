using AISV1.Models;
using AISV2.Models;
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
               new Customer{FirstName = "Alice", LastName="Amarson"},
               new Customer{FirstName = "Barbara", LastName="Benedict"},
               new Customer{FirstName = "Cecile", LastName="Crastor"},
               new Customer{FirstName = "Dirk", LastName="Dunham"}
            };

            foreach (Customer C in customers)
            {
                context.Customers.Add(C);
            }
            context.SaveChanges();

            var contactPersons = new ContactPerson[]
             {
               new ContactPerson{FirstName = "Alice CP", LastName="Amarson"},  
               new ContactPerson{FirstName = "Barbara CP", LastName="Benedict"},
               new ContactPerson{FirstName = "Cecile CP", LastName="Crastor"},
               new ContactPerson{FirstName = "Dirk CP", LastName="Dunham"}
             };

            foreach (ContactPerson CP in contactPersons)
            {
                context.ContactPersons.Add(CP);
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

            foreach (EventType ET in eventType)
            {
                context.EventType.Add(ET);
            }
            context.SaveChanges();

            var files = new File[]
            {
                new File{Name="TestDossier 1",EventTypeId=1, EventDate=DateTime.Parse("2019-01-01"),StartTime=DateTime.Now, EndTime=DateTime.Now, ArrivalOfOrganisers = DateTime.Now, AmountOfPeople = 10, AmountOfPeopleReception = 10, AmountOfPeopleDiningEst = 20, AmountOfPeopleDesertEst= 50 },
                new File{Name="TestDossier 2",EventTypeId=1, EventDate=DateTime.Parse("2019-01-01"),StartTime=DateTime.Now, EndTime=DateTime.Now, ArrivalOfOrganisers = DateTime.Now, AmountOfPeople = 10, AmountOfPeopleReception = 10, AmountOfPeopleDiningEst = 20, AmountOfPeopleDesertEst= 50 },
                new File{Name="TestDossier 3",EventTypeId=1, EventDate=DateTime.Parse("2019-01-01"),StartTime=DateTime.Now, EndTime=DateTime.Now, ArrivalOfOrganisers = DateTime.Now, AmountOfPeople = 10, AmountOfPeopleReception = 10, AmountOfPeopleDiningEst = 20, AmountOfPeopleDesertEst= 50 },
            };

            foreach (File F in files)
            {
                context.Files.Add(F);
            }
            context.SaveChanges();

            var fileCustomers = new FileCustomer[]
            {
                   new FileCustomer{CustomerID=1, FileID=1},
                   new FileCustomer{CustomerID=2, FileID=1},
                   new FileCustomer{CustomerID=2, FileID=2},
                   new FileCustomer{CustomerID=3, FileID=1}
            };

            foreach (FileCustomer FC in fileCustomers)
            {
                context.FileCustomers.Add(FC);
            }
            context.SaveChanges();

            var fileContactPerson = new FileContactPerson[]
             {
                   new FileContactPerson{ContactPersonID=1, FileID=1},
                   new FileContactPerson{ContactPersonID=2, FileID=1},
                   new FileContactPerson{ContactPersonID=2, FileID=2},
                   new FileContactPerson{ContactPersonID=3, FileID=1}
            };

            foreach (FileContactPerson FCP in fileContactPerson)
            {
                context.FileContactPersons.Add(FCP);
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

            foreach (FileRemark FM in fileRemarks)
            {
                context.FileRemarks.Add(FM);
            }
            context.SaveChanges();

            var meetings = new Meeting[]
             {
                new Meeting{Name="Eerste meeting", Location = "Meetingroom", FileID = 1 },
                new Meeting{Name="2de meeting", Location = "Meetingroom", FileID = 2 },
                new Meeting{Name="3de meeting", Location = "Meetingroom", FileID = 3 },
                new Meeting{Name="4de meeting", Location = "Meetingroom", FileID = 1 }
             };

            foreach (Meeting M in meetings)
            {
                context.Meetings.Add(M);
            }
            context.SaveChanges();
        }
    }
}
