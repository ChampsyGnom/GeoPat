using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PORTAIL_EQP",Schema="EQP")]
    public partial class EqpCdPortail
    {
        public virtual ICollection<EqpDscPo> EqpDscPos { get; set; }
        
        [Key]
        [Description("Portail")]
        [Column("CD_PORTAIL_EQP__PORTAIL",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Portail { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_PORTAIL_EQP__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_PORTAIL_EQP__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
