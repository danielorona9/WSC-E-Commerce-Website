using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    [Table("ProductCatalog")]
    public class ProductCatalog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCatalogID { get; set; }

        [ForeignKey("JobType")]
        public int JobTypeID { get; set; }

        [ForeignKey("MediaType")]
        public int MediaTypeID { get; set; }

        public int SkewNumber {get;set;}

        [Required(ErrorMessage = "Enter price of the product")]
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Enter description of the product")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public int StockAvailable { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        //connected tables that are on the one side
        public virtual JobTypes JobType { get; set; }
        public virtual MediaTypes MediaType { get; set; }
    }
}