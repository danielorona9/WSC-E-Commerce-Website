using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("MediaTypes")]
    public class MediaTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaTypeID { get; set; }

        [Display(Name = "Media Type")]
        public string MediaTypeName { get; set; }

        //connected tables on the many side
        public virtual ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}