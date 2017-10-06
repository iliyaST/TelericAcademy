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

            context.FriendsList.AddOrUpdate(
              f => f.Name,
              new FriendsList("testEmail")
              {
                  CreatedOn = DateTime.Now,
                  Friends = new List<Friend>()
                  {
                     new Friend("User1", false)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1995,10,4)
                      },
                     new Friend("User2", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1990,11,12)
                      }
                  }
              }
            );
        }
    }
}
