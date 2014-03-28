using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_DV_EQP",Schema="EQP")]
    public partial class EqpCdTypeDv
    {
        public virtual ICollection<EqpDscDv> EqpDscDvs { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("CD_TYPE_DV_EQP__CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TYPE_DV_EQP__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
    }
}
