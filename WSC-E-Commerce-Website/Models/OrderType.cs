using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("OrderType")]
    public class OrderType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderTypeID { get; set; }

        [Display(Name = "Order Type")]
        public string OrderTypeName { get; set; }
   
        //connected tables on the many side
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
    }
}