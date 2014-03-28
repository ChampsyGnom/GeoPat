using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_SV_EQP",Schema="EQP")]
    public partial class EqpCdFamSv
    {
        public virtual ICollection<EqpDscSv> EqpDscSvs { get; set; }
        
        public virtual ICollection<EqpCdTypeSv> EqpCdTypeSvs { get; set; }
        
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_SV_EQP__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("CD_FAM_SV_EQP__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
