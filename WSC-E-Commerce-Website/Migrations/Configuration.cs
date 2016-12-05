using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WSC_E_Commerce_Website.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WSC_E_Commerce_Website.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //work on insert data for application user table first
           // var ApplicationUser = new List<ApplicationUser>();
        
        }
    }
}
