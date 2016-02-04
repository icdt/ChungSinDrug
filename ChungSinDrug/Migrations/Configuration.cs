namespace ChungSinDrug.Migrations
{
    using icdtFramework.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<icdtFramework.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(icdtFramework.Models.ApplicationDbContext context)
        {
            DbSeed dbSeed = new DbSeed();

            dbSeed.SeedManagerAccout();
        }
    }
}
