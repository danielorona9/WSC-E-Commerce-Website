using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    [Table("PurchaseOrderStatus")]
    public class PurchaseOrderStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseOrderStatusID { get; set; }

        public string StatusName { get; set; }

        //connected tables on the many side
        public virtual ICollection<PurchaseOrders>PurchaseOrders { get; set; }
    }
}