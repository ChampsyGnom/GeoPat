using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FREQUENCE_BSN",Schema="BSN")]
    public partial class BsnCdFrequence
    {
        [Key]
        [Description("Fréquence")]
        [Column("FREQ",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Freq { get; set; }
        
    }
}
