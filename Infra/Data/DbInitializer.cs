using abc.Facade.Models;
using System;
using System.Linq;

namespace abc.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EventsDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Events.Any())
                return;

            var events = new Event[]
            {
                new Event{ 
                    Title = "Tanci-Shmanci", 
                    Date = DateTime.Parse("2021-03-22"), 
                    Location = "Lindakivi"},
                new Event{ 
                    Title = "Exhibition GENE-IUS", 
                    Date = DateTime.Parse("2021-04-24"), 
                    Location = "Saku Suurhall"},
                new Event{ 
                    Title = "Egypt of Glory", 
                    Date = DateTime.Parse("2021-05-26"), 
                    Location = "Linnahall"},
                new Event{ 
                    Title = "Ghost Tour in Tallinn Old Town", 
                    Date = DateTime.Parse("2021-05-20"), 
                    Location = "Old Town"},
                new Event{ 
                    Title = "Good Friday concert", 
                    Date = DateTime.Parse("2021-06-18"), 
                    Location = "Kadriorg"}
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}
