using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain;

namespace App.Db
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Activities.Any())
            {
                var Activities = new List<Activity>
                {
                    new Activity {
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub"
                    },
                    new Activity {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre"
                    },
                    new Activity {
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in the future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Month"
                    }
                };
                context.Activities.AddRange(Activities);
                context.SaveChanges();
            }
        }
    }
}