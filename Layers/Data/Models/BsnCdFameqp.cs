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
        [Key]
        [Description("Famille EQP")]
        [Column("FAM",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Fam { get; set; }
        
    }
}
