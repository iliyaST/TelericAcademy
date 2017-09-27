namespace MVCTemplate.Data.Migrations
{
    using MVCTemplate.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Groups.AddOrUpdate(
              g => g.Name,
              new Group("Birthdays")
            );

        }
    }
}
