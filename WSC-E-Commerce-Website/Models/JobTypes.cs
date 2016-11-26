using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("JobTypes")]
    public class JobTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobTypeID { get; set; }

        [Display(Name ="Job Type")]
        public string JobTypeName { get; set; }

        //connected tables that are on the many side
        public virtual ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}