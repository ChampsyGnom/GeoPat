using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FRANCH_EQP",Schema="EQP")]
    public partial class EqpCdFranch
    {
        public virtual ICollection<EqpDscCl> EqpDscCls { get; set; }
        
        [Key]
        [Description("Anti franchissement")]
        [Column("CD_FRANCH_EQP__ANTI_FRANCH",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String AntiFranch { get; set; }
        
    }
}
