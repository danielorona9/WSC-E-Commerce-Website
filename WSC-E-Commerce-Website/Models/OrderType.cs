using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class OrderType
    {
        public int OrderTypeID { get; set; }

        public string OrderTypeName { get; set; }
   
        //connected tables on the many side
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
    }
}