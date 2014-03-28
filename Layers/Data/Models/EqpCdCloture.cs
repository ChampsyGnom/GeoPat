using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CLOTURE_EQP",Schema="EQP")]
    public partial class EqpCdCloture
    {
        public virtual ICollection<EqpDscCl> EqpDscCls { get; set; }
        
        [Key]
        [Description("Clôture")]
        [Column("CD_CLOTURE_EQP__CLOTURE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Cloture { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_CLOTURE_EQP__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_CLOTURE_EQP__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
