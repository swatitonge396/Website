namespace Website.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Website.DBService;
    using Website.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Website.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Website.Models.MyDbContext context)
        {
            SeedMyDb DbSeed = new SeedMyDb();
            DbSeed.FillDB(context);
        }
    }
}
