using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPEQP_BSN",Schema="BSN")]
    public partial class BsnCdTypeqp
    {
        [Key]
        [Description("Famille EQP")]
        [Column("CD_FAMEQP_BSN__FAM",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdFameqpBsnFam { get; set; }
        
        [Key]
        [Description("Type EQP")]
        [Column("TYPE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("GARANTIE",Order=2)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("DVT",Order=3)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
