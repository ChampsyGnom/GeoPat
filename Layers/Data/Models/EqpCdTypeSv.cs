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
        public virtual EqpCdFamSv EqpCdFamSv {get;set;}
        
        public virtual ICollection<EqpCdStypeSv> EqpCdStypeSvs { get; set; }
        
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_SV_EQP__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String CdFamSvEqpFamille { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("CD_TYPE_SV_EQP__TYPE",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String Type { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TYPE_SV_EQP__LIBELLE",Order=2)]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
    }
}
