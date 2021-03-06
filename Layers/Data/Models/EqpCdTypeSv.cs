using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_SV_EQP",Schema="EQP")]
    public partial class EqpCdTypeSv
    {
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_SV_EQP__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String CdFamSvEqpFamille { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("TYPE",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String Type { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
    }
}
