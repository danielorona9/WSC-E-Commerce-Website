using System.Collections.Generic;
using Microsoft.AspNet.Identity;
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
            var creditCardTypes = new List<CreditCardType>
            {
                new CreditCardType {CreditCardTypeId = 1, CreditCardTypeName = "Visa"},
                new CreditCardType {CreditCardTypeId = 2, CreditCardTypeName = "MasterCard"},
                new CreditCardType {CreditCardTypeId = 3, CreditCardTypeName = "American Express"}
            };

            creditCardTypes.ForEach(s => context.CreditCardTypes.AddOrUpdate(p => p.CreditCardTypeId, s));
            context.SaveChanges();

            var jobTypes = new List<JobTypes>
            {
                new JobTypes {JobTypeID = 1, JobTypeName = "Printing"},
                new JobTypes {JobTypeID = 2, JobTypeName = "Engraving"}
            };

            jobTypes.ForEach(s => context.JobTypes.AddOrUpdate(p => p.JobTypeID, s));
            context.SaveChanges();

            var mediaTypes = new List<MediaTypes>
            {
                new MediaTypes() {MediaTypeID = 1, MediaTypeName = "Cloth"},
                new MediaTypes() {MediaTypeID = 2, MediaTypeName = "Plaque"},
                new MediaTypes() {MediaTypeID = 3, MediaTypeName = "Trophy"}
            };

            mediaTypes.ForEach(s => context.MediaTypes.AddOrUpdate(p => p.MediaTypeID, s));
            context.SaveChanges();

            var products = new List<ProductCatalog>
            {
                new ProductCatalog { ProductCatalogID = 1, JobTypeID = jobTypes.Single(x => x.JobTypeID == 1).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 1).MediaTypeID, Description = "Blank Black shirt",  Price = 19.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/BlackShirt.jpg", SkewNumber = 111},
                new ProductCatalog { ProductCatalogID = 2, JobTypeID = jobTypes.Single(x => x.JobTypeID == 1).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 1).MediaTypeID, Description = "Blank Grey Shirt",  Price = 19.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/GreyShirt.jpg", SkewNumber = 211},
                new ProductCatalog { ProductCatalogID = 3, JobTypeID = jobTypes.Single(x => x.JobTypeID == 1).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 1).MediaTypeID, Description = "Blank Blue shirt",  Price = 19.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/BlueShirt.jpg", SkewNumber = 311},

                new ProductCatalog { ProductCatalogID = 4, JobTypeID = jobTypes.Single(x => x.JobTypeID == 2).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 2).MediaTypeID, Description = "Blank Gold Plaque",  Price = 29.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/GoldPLaques.jpg", SkewNumber = 422},
                new ProductCatalog { ProductCatalogID = 5, JobTypeID = jobTypes.Single(x => x.JobTypeID == 2).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 2).MediaTypeID, Description = "Blank Silver Plaque",  Price = 29.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/SilverPlaque.jpg", SkewNumber = 522},
                new ProductCatalog { ProductCatalogID = 6, JobTypeID = jobTypes.Single(x => x.JobTypeID == 2).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 2).MediaTypeID, Description = "Blank Group Plaque",  Price = 29.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/GroupPlaque.jpg", SkewNumber = 622},

                new ProductCatalog { ProductCatalogID = 7, JobTypeID = jobTypes.Single(x => x.JobTypeID == 2).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 3).MediaTypeID, Description = "Blank Gold Trophy",  Price = 29.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/GoldTrophy.jpg", SkewNumber = 723},
                new ProductCatalog { ProductCatalogID = 8, JobTypeID = jobTypes.Single(x => x.JobTypeID == 2).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 3).MediaTypeID, Description = "Blank Silver Trophy", Price = 29.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/SilverTrophy.jpg", SkewNumber = 823},
                new ProductCatalog { ProductCatalogID = 9, JobTypeID = jobTypes.Single(x => x.JobTypeID == 2).JobTypeID, MediaTypeID = mediaTypes.Single(x => x.MediaTypeID == 3).MediaTypeID, Description = "Blank Bronze Trophy",  Price = 29.99M, StockAvailable = 100, ProductImage = "~/content/images/CatalogProducts/BronzeTrophy.jpg", SkewNumber = 923}
            };
            products.ForEach(s => context.ProductCatalog.AddOrUpdate(p => p.ProductCatalogID, s));
            context.SaveChanges();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(SecurityRoles.Admin))
            {
                var roleresult = roleManager.Create(new IdentityRole(SecurityRoles.Admin));
            }
            if (!roleManager.RoleExists(SecurityRoles.OperationsManager))
            {
                var roleresult = roleManager.Create(new IdentityRole(SecurityRoles.OperationsManager));
            }
            if (!roleManager.RoleExists(SecurityRoles.SalesClerk))
            {
                var roleresult = roleManager.Create(new IdentityRole(SecurityRoles.SalesClerk));
            }

            var adminUserName = "admin@wsc.com";
            var adminPassword = "Password#1";

            ApplicationUser adminUser = userManager.FindByName(adminUserName);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = adminUserName,
                    Email = adminUserName,
                    EmailConfirmed = true,
                    FirstName = "john",
                    LastName = "smith",
                    Address1 = "123 happy lane",
                    Address2 = "",
                    City = "lakewood",
                    State = "ca",
                    Zip = 90803
                };
                // var user = new ApplicationUser { UserName = model.Email, Email = model.Email,FirstName = model.FirstName, LastName = model.LastName, Address1 = model.Address1, Address2 = model.Address2, City = model.City, State = model.State, Zip = model.Zip};
                IdentityResult userResult = userManager.Create(adminUser, adminPassword);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(adminUser.Id, SecurityRoles.Admin);
                }
            }

            var managerUserName = "manager@wsc.com";
            var managerPassword = "Password#1";

            ApplicationUser opUser = userManager.FindByName(managerUserName);
            if (opUser == null)
            {
                opUser = new ApplicationUser()
                {
                    UserName = managerUserName,
                    Email = managerUserName,
                    EmailConfirmed = true,
                    FirstName = "john",
                    LastName = "smith",
                    Address1 = "123 happy lane",
                    Address2 = "",
                    City = "lakewood",
                    State = "ca",
                    Zip = 90803
                };
                IdentityResult userResult = userManager.Create(opUser, managerPassword);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(opUser.Id, SecurityRoles.OperationsManager);
                }
            }

            var scUserName = "salesClerk@wsc.com";
            var scPassword = "Password#1";

            ApplicationUser scUser = userManager.FindByName(scUserName);
            if (scUser == null)
            {
                scUser = new ApplicationUser()
                {
                    UserName = scUserName,
                    Email = scUserName,
                    EmailConfirmed = true,
                    FirstName = "john",
                    LastName = "smith",
                    Address1 = "123 happy lane",
                    Address2 = "",
                    City = "lakewood",
                    State = "ca",
                    Zip = 90803
                };
                IdentityResult userResult = userManager.Create(scUser, scPassword);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(scUser.Id, SecurityRoles.SalesClerk);
                }
            }
        }
    }
}
