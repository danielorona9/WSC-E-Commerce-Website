using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("OrderRequest")]
    public class OrderRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderRequestID { get; set; }

        [ForeignKey("ProductCatalog")]
        public int ProductCatalogID { get; set; }

        [ForeignKey("PurchaseOrders")]
        public int PurchaseOrdersID { get; set; }

        public string CartId { get; set; }

        [Required(ErrorMessage ="Enter quantity amount")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Enter the content")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //connected tables on the one side
        public virtual ProductCatalog ProductCatalog { get; set; }
        public virtual PurchaseOrders PurchaseOrders { get; set; }
    }
}