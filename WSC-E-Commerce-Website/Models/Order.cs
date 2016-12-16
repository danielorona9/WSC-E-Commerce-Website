using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WSC_E_Commerce_Website.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string ApplicationUserId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public ICollection<OrderRequest> OrderRequests { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}