using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAMEQP_BSN",Schema="BSN")]
    public partial class BsnCdFameqp
    {
        public virtual ICollection<BsnCdTypeqp> BsnCdTypeqps { get; set; }
        
        [Key]
        [Description("Famille EQP")]
        [Column("CD_FAMEQP_BSN__FAM",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Fam { get; set; }
        
    }
}
