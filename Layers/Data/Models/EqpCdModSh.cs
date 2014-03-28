using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MOD_SH_EQP",Schema="EQP")]
    public partial class EqpCdModSh
    {
        public virtual ICollection<EqpCdMarquageSh> EqpCdMarquageShs { get; set; }
        
        [Key]
        [Description("Modulation")]
        [Column("CD_MOD_SH_EQP__MOD",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Mod { get; set; }
        
        [Description("Libellé")]
        [Column("CD_MOD_SH_EQP__LIBELLE",Order=1)]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
    }
}
