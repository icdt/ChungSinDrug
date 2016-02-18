

namespace ChungSinDrug.Migrations
{
    using global::icdtFramework.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            DbSeed dbSeed = new DbSeed();

            dbSeed.SeedManagerAccout();
        }
    }
}
