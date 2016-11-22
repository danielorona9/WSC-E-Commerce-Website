using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class PurchaseOrderStatus
    {
        public int PurchaseOrderStatusID { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<PurchaseOrders>PurchaseOrders { get; set; }
    }
}