using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MAT_SV_EQP",Schema="EQP")]
    public partial class EqpCdMatSv
    {
        public virtual ICollection<EqpPanneau> EqpPanneaus { get; set; }
        
        [Key]
        [Description("Matériaux")]
        [Column("CD_MAT_SV_EQP__MATERIAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Materiaux { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_MAT_SV_EQP__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_MAT_SV_EQP__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
