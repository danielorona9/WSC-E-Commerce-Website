using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("PurchaseOrders")]
    public class PurchaseOrders
    {
        [Key]
        public int PurchaseOrdersID { get; set; }

        //TODO Remove RecordId column from database
        //public int RecordId { get; set; }

        public string CartID { get; set; }

        [ForeignKey("ProductCatalog")]
        public int ProductCatalogID { get; set; }
        public int Count { get; set; }
       
        [Display(Name = "Date Ordered")]
        [DataType(DataType.Date)]
        public System.DateTime OrderDate { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name ="Deposit Amount")]
        [DataType(DataType.Currency)]
        public decimal Deposit { get; set; }

        public string ApplicationUserID { get; set; }

        //connected tables on the one side          
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ProductCatalog ProductCatalog { get; set; }

        //connected tables on the many side
        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
    
    }
}