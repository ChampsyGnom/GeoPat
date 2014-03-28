using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_POTEAU_CL_EQP",Schema="EQP")]
    public partial class EqpCdPoteauCl
    {
        public virtual ICollection<EqpDscCl> EqpDscCls { get; set; }
        
        [Key]
        [Description("Poteaux")]
        [Column("CD_POTEAU_CL_EQP__POTEAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Poteaux { get; set; }
        
    }
}
