using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FABRICANT_EQP",Schema="EQP")]
    public partial class EqpCdFabricant
    {
        public virtual ICollection<EqpDscSh> EqpDscShs { get; set; }
        
        public virtual ICollection<EqpDscPo> EqpDscPos { get; set; }
        
        public virtual ICollection<EqpPanneau> EqpPanneaus { get; set; }
        
        public virtual ICollection<EqpDscCl> EqpDscCls { get; set; }
        
        public virtual ICollection<EqpDscEs> EqpDscEss { get; set; }
        
        public virtual ICollection<EqpDscDv> EqpDscDvs { get; set; }
        
        [Key]
        [Description("Nom Fabricant")]
        [Column("CD_FABRICANT_EQP__NOM",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
    }
}
