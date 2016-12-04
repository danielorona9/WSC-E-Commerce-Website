using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
     
        }
        public DbSet<BillingInfo> BillingInfos { get; set; }
        public DbSet<CreditCardType> CreditCardTypes { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PurchaseOrderStatus> PurchaseOrderStatuses { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<ProductCatalog> ProductCatalog { get; set; }
        public DbSet<JobTypes> JobTypes { get; set; }
        public DbSet<MediaTypes>MediaTypes { get; set; }        
        public DbSet<OrderRequest> OrderRequests { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserID");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimID");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleID");
            modelBuilder.Entity<BillingInfo>().HasRequired(n => n.ApplicationUser).WithMany((a => a.BillingInfo)).HasForeignKey(n => n.ApplicationUserID).WillCascadeOnDelete(true);
            modelBuilder.Entity<PurchaseOrders>().HasRequired(n => n.ApplicationUser).WithMany(a => a.PurchaseOrders).HasForeignKey(n => n.ApplicationUserID ).WillCascadeOnDelete(false);
            
        }

        public System.Data.Entity.DbSet<WSC_E_Commerce_Website.Models.EmployeeType> EmployeeTypes { get; set; }

        public System.Data.Entity.DbSet<WSC_E_Commerce_Website.Models.Employee> Employees { get; set; }
    }
}