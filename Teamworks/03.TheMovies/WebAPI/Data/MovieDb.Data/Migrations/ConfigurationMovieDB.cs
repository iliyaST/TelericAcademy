namespace MovieDb.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    public sealed class ConfigurationMovieDB : DbMigrationsConfiguration<MoviesContext>
    {
        public ConfigurationMovieDB()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MovieDb.Data.MoviesContext context)
        {
            
        }
    }
}
