namespace MVCTemplate.Data.Migrations
{
    using MVCTemplate.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BirthdaySite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
            ContextKey = "BirthdaySite.Models.ApplicationDbContext";
        }

        protected override void Seed(BirthdaySite.Models.ApplicationDbContext context)
        {
            context.Groups.AddOrUpdate(
              g => g.Name,
              new Group("Birthdays")
              {
                  CreatedOn = DateTime.Now,
                  Messages = new List<Message>()
                  {
                      new Message()
                      {
                          Author = "RandomUser",
                          Content = "Testing my forum page..."
                      },
                      new Message()
                      {
                          Author = "RandomUser1",
                          Content = "Testing my forum pageia...Using !important in your CSS usually means you're narcissistic & selfish or lazy. Respect the devs to come..."
                      }
                  }
              },
              new Group("Presents")
              {
                  CreatedOn = DateTime.Now,
                  Messages = new List<Message>()
                  {
                      new Message()
                      {
                          Author = "RandomUser",
                          Content = "Testing my forum page..."
                      },
                      new Message()
                      {
                          Author = "RandomUser1",
                          Content = "Testing my forum pageia...Using !important in your CSS usually means you're narcissistic & selfish or lazy. Respect the devs to come..."
                      }
                  }
              }
            );
        }
    }
}
